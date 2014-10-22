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
        /// Service Type ID
        /// </summary>
        public long ServiceTypeId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDate { get; set; }

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
        /// Service Type
        /// </summary>
        public virtual ServiceType ServiceType { get; set; }

        #endregion
    }
}
