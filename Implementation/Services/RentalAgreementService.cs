using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.Helpers;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Rental Agreement ervice
    /// </summary>
    public class RentalAgreementService : IRentalAgreementService
    {
        #region Private
        
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IBill bill;
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly IAlloactionStatusRepository alloactionStatusRepository;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementService(IPaymentTermRepository paymentTermRepository, IOperationRepository operationRepository, 
            IOperationsWorkPlaceRepository operationsWorkPlaceRepository, ITariffTypeRepository tariffTypeRepository, IBill bill,
            IVehicleStatusRepository vehicleStatusRepository, IAlloactionStatusRepository alloactionStatusRepository)
        {
            if (paymentTermRepository == null)
            {
                throw new ArgumentNullException("paymentTermRepository");
            }

            if (operationRepository == null)
            {
                throw new ArgumentNullException("operationRepository");
            }
            if (operationsWorkPlaceRepository == null)
            {
                throw new ArgumentNullException("operationsWorkPlaceRepository");
            }
            if (tariffTypeRepository == null) throw new ArgumentNullException("tariffTypeRepository");
            if (bill == null) throw new ArgumentNullException("bill");
            if (vehicleStatusRepository == null) throw new ArgumentNullException("vehicleStatusRepository");
            if (alloactionStatusRepository == null) throw new ArgumentNullException("alloactionStatusRepository");

            this.paymentTermRepository = paymentTermRepository;
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.bill = bill;
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.alloactionStatusRepository = alloactionStatusRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Base Data
        /// </summary>
        public RentalAgreementBaseDataResponse GetBaseData()
        {
            return new RentalAgreementBaseDataResponse
            {
                PaymentTerms = paymentTermRepository.GetAll(),
                Operations = operationRepository.GetSalesOperation(),
                OperationsWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace(),
                AllocationStatuses = alloactionStatusRepository.GetAll(),
                VehicleStatuses = vehicleStatusRepository.GetAll()
            };
        }

        /// <summary>
        /// Generates Bill For RA
        /// </summary>
        public RaMain GenerateBill(RaMain request)
        {
            List<TariffType> tariffTypes = tariffTypeRepository.GetAll().ToList();
            RaMain raMain = request;

            bill.CalculateBill(ref raMain, tariffTypes);
            
            return raMain;
        }

        #endregion
    }
}
