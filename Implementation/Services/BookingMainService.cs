using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Additional Charge Service
    /// </summary>
    public class BookingMainService : IBookingMainService
    {
        #region Private

        private readonly IBookingInsuranceRepository bookingInsuranceRepository;
        private readonly IBookingBookingAdditionalDriverRepository bookingAdditionalDriverRepository;
        private readonly IBookingMainRepository bookingMainRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;

        #endregion
        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public BookingMainService(IBookingInsuranceRepository bookingInsuranceRepository, IBookingBookingAdditionalDriverRepository bookingAdditionalDriverRepository,
            IBookingMainRepository bookingMainRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
        {
            this.bookingMainRepository = bookingMainRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.bookingInsuranceRepository = bookingInsuranceRepository;
            this.bookingAdditionalDriverRepository = bookingAdditionalDriverRepository;
        }

        #endregion 
        #region Public

        public BookingMainBaseResponse GetBaseData()
        {
            return new BookingMainBaseResponse
            {
                OperationWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace()
            };
        }

        /// <summary>
        /// Sumition of Main Booking 
        /// </summary>
        public bool AddBookingMainRequest(int[] insurancesIndex, int[] chauffersIndexInts,
            WebApiAdditionalDriverInfo driverInfo , WebApiBookingMainInfo bookingMainInfo)
        {
            long operationId =
                operationsWorkPlaceRepository.GetOperationIdByOperationWorkPlaceId(bookingMainInfo.OperationWorkPlaceId);
            var bookingMain = SaveBookingMain(bookingMainInfo,operationId);
            SaveInsuranceRate(insurancesIndex, bookingMain);
            SaveAdditionalDriver(driverInfo, bookingMain);
            return true;
        }

        public BookingMainResponse LoadMainBookings(BookingMainSearchRequest request)
        {
            return bookingMainRepository.LoadMainBookings(request);
        }

        private BookingMain SaveBookingMain(WebApiBookingMainInfo source, long operationId)
        {
            var bookingMain = bookingMainRepository.Find(0);
            if (bookingMain == null)
            {
                bookingMain = new BookingMain
                {
                    OpenLocation = source.OperationWorkPlaceId,
                    CloseLocation = source.OperationWorkPlaceId,
                    BookingMainDescription = "Remote Reservation!",
                    StartDtTime = source.StartDateTime,
                    EndDtTime = source.EndtDateTime,
                    RowVersion = 0,
                    IsActive = true,
                    IsDeleted = false,
                    IsPrivate = false,
                    IsReadOnly = false,
                    RecCreatedDt = DateTime.Now,
                    RecCreatedBy = "Baqer",
                    RecLastUpdatedDt = DateTime.Now,
                    RecLastUpdatedBy = "Baqer",
                    BookingStatusId = 1,
                    PaymentTermId = 1,
                    OperationId = operationId,
                    UserDomainKey = 1,
                    HireGroupDetailId = source.HireGroupDetailId
                };
                bookingMainRepository.Add(bookingMain);
                bookingMainRepository.SaveChanges();
                return bookingMainRepository.Find(bookingMain.BookingMainId);
            }
            return new BookingMain();
        }

        private void SaveInsuranceRate(IEnumerable<int> insuranceTypeIds, BookingMain bookingMain)
        {
            if (insuranceTypeIds!=null)
            foreach (var insuranceTypeId in insuranceTypeIds)
            {
                var bookingIsurance = bookingInsuranceRepository.Find(0);
                if (bookingIsurance == null)
                {
                    bookingIsurance = new BookingIsurance
                    {
                        BookingMainId = bookingMain.BookingMainId,
                        InsuranceTypeId =(short) insuranceTypeId,
                        StartDate = bookingMain.StartDtTime,
                        EndDate = bookingMain.EndDtTime,
                        UserDomainKey = 1
                    };
                    bookingInsuranceRepository.Add(bookingIsurance);
                    bookingInsuranceRepository.SaveChanges();
                }
            }
        }

        private void SaveAdditionalDriver(WebApiAdditionalDriverInfo additionalDriverInfo, BookingMain bookingMain)
        {
            var bookingAdditionalDriver = bookingAdditionalDriverRepository.Find(0);
            if (bookingAdditionalDriver == null && additionalDriverInfo.Name!=null)
            {
                bookingAdditionalDriver = new BookingAdditionalDriver
                {
                    AdditionDriverName = additionalDriverInfo.Name,
                    AdditionaDriverLicenseNo = additionalDriverInfo.LicenseNumber,
                    AdditionalDriverLicenseExpDt = additionalDriverInfo.LicenseExpDate,
                    BookingMainId = bookingMain.BookingMainId
                };
                bookingAdditionalDriverRepository.Add(bookingAdditionalDriver);
                bookingAdditionalDriverRepository.SaveChanges();
            }
        }

        #endregion
    }
}
