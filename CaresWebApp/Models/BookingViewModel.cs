using System;

namespace Cares.WebApp.Models
{
    /// <summary>
    /// Booking Model
    /// </summary>
    public class BookingViewModel
    {
        public string OperationWorkPlaceCode { get; set; }

        /// <summary>
        /// Operation WorkPlace ID
        /// </summary>
        public long OperationWorkPlaceId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDt { get; set; }

        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public  long HireGroupDetailId { get; set; }
    }
}