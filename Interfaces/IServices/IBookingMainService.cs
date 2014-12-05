
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    
    public interface IBookingMainService
    {
        /// <summary>
        /// Get Booking Main Base Data
        /// </summary>
        /// <returns></returns>
        BookingMainBaseResponse GetBaseData();

        /// <summary>
        /// Submit Main Booking 
        /// </summary>
        bool AddBookingMainRequest(int[] insurancesIndex, int[] chauffersIndexInts, WebApiAdditionalDriverInfo driverInfo , WebApiBookingMainInfo bookingMainInfo);

        /// <summary>
        /// Load Main Bookings, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BookingMainResponse LoadMainBookings(BookingMainSearchRequest request);
    }
}
