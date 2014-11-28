
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;

namespace Cares.WebApi.ModelMappers
{
    public static class BookingMainMapper
    {
       public static WebApiAdditionalDriverInfo CreateFrom(this AdditionalDriverInfo driverInfo)
        {
            return new WebApiAdditionalDriverInfo
            {
                Name = driverInfo.Name,
                Rate = driverInfo.Rate,
                LicenseNumber = driverInfo.LicenseNumber,
                LicenseExpDate = driverInfo.LicenseExpDate
            };
        }

        /// <summary>
        /// API booking model to cares booking model
        /// </summary>
       public static Cares.Models.ResponseModels.WebApiBookingMainInfo CreateFrom(this Models.WebApiBookingMainInfo source)
       {
           return new Cares.Models.ResponseModels.WebApiBookingMainInfo
           {
               HireGroupDetailId = source.HireGroupDetailId,
               OperationWorkPlaceId = source.OperationWorkPlaceId,
               TariffTypeCode = source.TariffTypeCode,
               StartDateTime = source.StartDateTime,
               EndtDateTime = source.EndtDateTime
           };
       }
    }
}