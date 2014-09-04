namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Check List Item Web Model
    /// </summary>
    public class VehicleCheckListItem
    {
        /// <summary>
        /// Vehicle Check List Item ID
        /// </summary>
        public long VehicleCheckListItemId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Vehicle Check List ID
        /// </summary>
        public short? VehicleCheckListId { get; set; }

        /// <summary>
        /// Vehicle Check List Code Name
        /// </summary>
        public string VehicleCheckListCodeName { get; set; }
    }
}