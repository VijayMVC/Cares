using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Isurance Domain Model
    /// </summary>
    public class BookingIsurance
    {
        #region Public Properties

        /// <summary>
        /// Booking Insurance ID
        /// </summary>
        public long BookingInsuranceId { get; set; }

        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
        public long InsuranceTypeId { get; set; }

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
        /// Insurance Type
        /// </summary>
        public virtual InsuranceType InsuranceType { get; set; }
        #endregion
    }
}
