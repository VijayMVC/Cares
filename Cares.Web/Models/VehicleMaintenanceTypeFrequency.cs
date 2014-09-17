using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Maintenance Type Frequency Web Model
    /// </summary>
    public class VehicleMaintenanceTypeFrequency
    {
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
        /// Maintenance Type Code Name
        /// </summary>
        public string MaintenanceTypeCodeName { get; set; }
    }
}