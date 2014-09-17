using System;

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
        public long MaintenanceTypeFrequencyId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Maintenance Start Date
        /// </summary>
        public DateTime? MaintenanceStartDate { get; set; }

        /// <summary>
        /// Frequency
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// Frequency Kilo Meter
        /// </summary>
        public int? FrequencyKiloMeter { get; set; }

        /// <summary>
        /// Maintenance Type ID
        /// </summary>
        public short? MaintenanceTypeId { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
       
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

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

        /// <summary>
        /// Maintenance Type
        /// </summary>
        public virtual MaintenanceType MaintenanceType { get; set; }

        #endregion
    }
}
