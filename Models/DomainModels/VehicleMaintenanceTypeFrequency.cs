using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Maintenance Type Frequency
    /// </summary>
    public class VehicleMaintenanceTypeFrequency
    {
        #region Persisted Properties

        /// <summary>
        /// Maintenance Type Frequency ID
        /// </summary>
        [Key]
        public short MaintenanceTypeFrequencyId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Maintenance Start Date
        /// </summary>
        [Required]
        public DateTime MaintenanceStartDate { get; set; }

        /// <summary>
        /// Frequency
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Frequency Kilo Meter
        /// </summary>
        public int FrequencyKiloMeter { get; set; }

        /// <summary>
        /// Maintenance Type ID
        /// </summary>
        [ForeignKey("MaintenanceType")]
        public short MaintenanceTypeId { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
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
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }


        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Maintenance Type
        /// </summary>
        public virtual MaintenanceType MaintenanceType { get; set; }

        #endregion
    }
}
