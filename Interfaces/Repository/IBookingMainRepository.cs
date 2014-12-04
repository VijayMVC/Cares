using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Booking Main Repository Interface
    /// </summary>
    public interface IBookingMainRepository : IBaseRepository<BookingMain, long>
    {
        /// <summary>
        /// Load Main Bookings, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BookingMainResponse LoadMainBookings(BookingMainSearchRequest request);
    }
}
