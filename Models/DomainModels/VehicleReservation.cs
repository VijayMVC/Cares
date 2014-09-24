using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Reservation Domain Model
    /// </summary>
    public class VehicleReservation
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Reservation ID
        /// </summary>
        public long VehicleReservationId { get; set; }

        /// <summary>
        /// Start Date Time
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date Time
        /// </summary>
        public DateTime EndDtTime { get; set; }
        
        /// <summary>
        /// Vehicle Reservation Description
        /// </summary>
        public string VehicleReservationDescription { get; set; }

        /// <summary>
        /// Vehicle Id
        /// </summary>
        public long VehicleId { get; set; }
        
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
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

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
