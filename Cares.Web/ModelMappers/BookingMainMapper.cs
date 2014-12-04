using System.Linq;
using DomainModels = Cares.Models.DomainModels;
using ApiModels = Cares.Web.Models;
using DomainResponseModel = Cares.Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    public static class BookingMainMapper
    {
        #region Base Data Mapper

        /// <summary>
        /// Base Response Mapper
        /// </summary>
        public static ApiModels.BookingMainBaseResponse CreateFrom(this DomainResponseModel.BookingMainBaseResponse source)
        {
            return new ApiModels.BookingMainBaseResponse
            {
                OperationWorkPlaces = source.OperationWorkPlaces.Select(m => m.CreateFromDropDown())
            };
        }

        #endregion
        #region Public

        /// <summary>
        ///  BookingMain Search Response Mapper
        /// </summary>
        public static ApiModels.BookingMainSearchResponse CreateFrom(this DomainResponseModel.BookingMainResponse source)
        {
            return new ApiModels.BookingMainSearchResponse
            {
                BookingMains = source.BookingMains.Select(x => x.CreateFrom()).ToList(),
                TotalCount = source.TotalCount,
            };
        }

        /// <summary>
        ///  BookingMain Search Response Mapper
        /// </summary>
        public static ApiModels.BookingMain CreateFrom(this DomainModels.BookingMain source)
        {
            return new ApiModels.BookingMain
            {
                BookingMainId = source.BookingMainId,
                CloseLocation = source.OperationsWorkPlaceClose.LocationCode + " - " + source.OperationsWorkPlaceClose.LocationName,
                OpenLocation = source.OperationsWorkPlaceOpen.LocationCode + " - "+ source.OperationsWorkPlaceOpen.LocationName,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                OperationCode = source.Operation.OperationCode,
                StatusCode = source.BookingStatus.BookingStatusCode
            };
        }
        #endregion
    }
}