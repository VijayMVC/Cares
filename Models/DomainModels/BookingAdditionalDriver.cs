using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Additional Driver Domain Model
    /// </summary>
    public class BookingAdditionalDriver
    {
        #region Public Properties

        /// <summary>
        /// Booking Addition Driver ID
        /// </summary>
        public long BookingAdditionDriverId { get; set; }

        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Addition Driver Name
        /// </summary>
        public string AdditionDriverName { get; set; }

        /// <summary>
        /// Additiona Driver License No.
        /// </summary>
        public string AdditionaDriverLicenseNo { get; set; }

        /// <summary>
        /// Additional Driver License Expiry Date
        /// </summary>
        public DateTime AdditionalDriverLicenseExpDt { get; set; }
        #endregion

        #region Reference Properties

        /// <summary>
        /// Booking Main
        /// </summary>
        public virtual BookingMain BookingMain { get; set; }
        #endregion
    }
}
