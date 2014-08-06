using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Detail Web Model
    /// </summary>
    public class HireGroupDetailContent
    {
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; } 
        /// <summary>
        /// Standard Rate Main Id
        /// </summary>
        public long StandardRateMainId { get; set; } 
        /// <summary>
        /// Standard Rate Id
        /// </summary>
        public long StandardRtId { get; set; }
        /// <summary>
        /// Hire Group
        /// </summary>
        public string HireGroup { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string VehicleMake { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string VehicleModel { get; set; }
        /// <summary>
        /// Vehicle Category
        /// </summary>
        public string VehicleCategory { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Allow Mileage
        /// </summary>
        public float? AllowMileage { get; set; }
        /// <summary>
        /// Excess Mileage Charge
        /// </summary>
        public float? ExcessMileageCharge { get; set; }
        /// <summary>
        /// Standard Rate
        /// </summary>
        public float? StandardRt { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// End Date
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Selected hire group for standard rate main
        /// </summary>
        public bool IsChecked { get; set; }

    }
}