using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Booking Main Base Response
    /// </summary>
    public class BookingMainBaseResponse
    {
        /// <summary>
        /// Operation Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlaceDropDown> OperationWorkPlaces { get; set; }
    }
}