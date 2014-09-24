using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Chauffer Reservation Domain Model
    /// </summary>
    public class ChaufferReservation
    {
        #region Persisted Properties
        
        /// <summary>
        /// Chauffer Reservation ID
        /// </summary>
        public long ChaufferReservationId { get; set; }

        /// <summary>
        /// Chauffer ID
        /// </summary>
        public long ChaufferId { get; set; }

        /// <summary>
        /// Start Date Time
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date Time
        /// </summary>
        public DateTime EndDtTime { get; set; }
        
        /// <summary>
        /// Chauffer Reservation Description
        /// </summary>
        public string ChaufferReservationDescription { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }


        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        /// <summary>
        /// BookingMain Id
        /// </summary>
        public long? BookingMainId { get; set; }

        /// <summary>
        /// NrtMain Id
        /// </summary>
        public long? NrtMainId { get; set; }

        /// <summary>
        /// RaMian Id
        /// </summary>
        public long? RaMainId { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Booking Main
        /// </summary>
        public virtual BookingMain BookingMain { get; set; }

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        /// <summary>
        /// Nrt Main
        /// </summary>
        public virtual NrtMain NrtMain { get; set; }

        #endregion
    }
}
