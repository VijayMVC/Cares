using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Insurance Rate Detail Content
    /// </summary>
    public sealed class InsuranceRtDetailContent
    {
        /// <summary>
        /// Insurance Rate Id
        /// </summary>
        public long InsuranceRtId { get; set; }
        /// <summary>
        /// Insurance Rate Main Id
        /// </summary>
        public long InsuranceRtMainId { get; set; }
        /// <summary>
        /// Insurance Rate Id
        /// </summary>
        public long InsuranceTypeId { get; set; }
        /// <summary>
        /// Insurance Type Code Name
        /// </summary>
        public string InsuranceTypeCodeName { get; set; }
        /// <summary>
        /// Hire Group Code Name
        /// </summary>
        public string HireGroupDetailCodeName { get; set; }
        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Vehicle Make Code Name
        /// </summary>
        public string VehicleMakeCodeName { get; set; }
        /// <summary>
        /// Vehicle Make Code Name
        /// </summary>
        public string VehicleModelCodeName { get; set; }
        /// <summary>
        /// Vehicle Category Code Name
        /// </summary>
        public string VehicleCategoryCodeName { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Insurance Rate
        /// </summary>
        public float? InsuranceRate { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Selected hire group for Insurance rate main
        /// </summary>
        public bool IsChecked { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
    }
}
