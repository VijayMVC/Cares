namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Detail For Hire Group
    /// </summary>
    public class HireGroupDetailForHireGroup
    {
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Vehicle Make Id
        /// </summary>
        public short VehicleMakeId { get; set; }
        /// <summary>
        /// Vehicle Category Id
        /// </summary>
        public short VehicleCategoryId { get; set; }
        /// <summary>
        /// Vehicle Model Id
        /// </summary>
        public short VehicleModelId { get; set; }
        /// <summary>
        /// Vehicle Make Code Name
        /// </summary>
        public string VehicleMakeCodeName { get; set; }
        /// <summary>
        /// Vehicle Category Name
        /// </summary>
        public string VehicleCategoryName { get; set; }
        /// <summary>
        /// Vehicle Model Code Name
        /// </summary>
        public string VehicleModelCodeName { get; set; }
        /// <summary>
        /// Vehicle Model Year
        /// </summary>
        public short VehicleModelYear { get; set; } 
    }
}