namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Detail Content ForHire Group
    /// </summary>
    public sealed class HireGroupDetailContentForHireGroup
    {
        /// <summary>
        /// Hire Group Detail Id
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
    }
}