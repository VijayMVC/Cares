
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

       public static WebApiBookingMainInfo CreateFrom(this BookingMainInfo source)
       {
           return new WebApiBookingMainInfo
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