
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    
    public interface IBookingMainService
    {
        /// <summary>
        /// Sumition of Main Booking 
        /// </summary>
        bool AddBookingMainRequest(int[] insurancesIndex, int[] chauffersIndexInts, WebApiAdditionalDriverInfo driverInfo , WebApiBookingMainInfo bookingMainInfo);
    }
}
