using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date Time
        /// </summary>
        [Required]
        public DateTime EndDtTime { get; set; }
        
        /// <summary>
        /// Vehicle Reservation Description
        /// </summary>
        [StringLength(500)]
        public string VehicleReservationDescription { get; set; }

        /// <summary>
        /// Vehicle Id
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }


        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        #endregion
    }
}
