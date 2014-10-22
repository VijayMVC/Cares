using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Chauffeur Domain Model
    /// </summary>
    public class BookingChauffeur
    {
        #region Public Properties

        /// <summary>
        /// Booking Chauffeur ID
        /// </summary>
        public long BookingChauffeurId { get; set; }

        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Chauffeur ID
        /// </summary>
        public long ChauffeurId { get; set; }

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

        #endregion
    }
}
