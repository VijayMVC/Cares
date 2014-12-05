using System;

namespace Cares.Web.Models
{
    public class BookingMain
    {
        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public string OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public string CloseLocation { get; set; }

        /// <summary>
        /// Booking Status Id
        /// </summary>
        public string StatusCode { get; set; }
        
        /// <summary>
        /// Operatiom Id
        /// </summary>
        public string OperationCode { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }
    }
}