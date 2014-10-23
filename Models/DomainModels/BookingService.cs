using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Service Domain Model
    /// </summary>
    public class BookingService
    {
        #region Public Properties

        /// <summary>
        /// Booking Service ID
        /// </summary>
        public long BookingServiceId { get; set; }

        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Service Item ID
        /// </summary>
        public long ServiceItemId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Booking Main
        /// </summary>
        public virtual BookingMain BookingMain { get; set; }

        /// <summary>
        /// Service Item
        /// </summary>
        public virtual ServiceItem ServiceItem { get; set; }

        #endregion
    }
}
