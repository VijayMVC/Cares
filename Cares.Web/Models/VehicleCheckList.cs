
namespace Cares.Web.Models
{
    /// <summary>
    /// web moel
    /// </summary>
    public class VehicleCheckList
    {
        /// <summary>
        ///Vehicle Check List Id
        /// </summary>
        public short VehicleCheckListId { get; set; }

        /// <summary>
        /// Vehicle Check List Code
        /// </summary>
        public string VehicleCheckListCode { get; set; }

        /// <summary>
        /// Vehicle Check List Name
        /// </summary>
        public string VehicleCheckListName { get; set; }

        /// <summary>
        /// Vehicle Check List Code Name
        /// </summary>
        public string VehicleCheckListCodeName { get; set; }

        /// <summary>
        /// Vehicle Check List Description
        /// </summary>
        public string VehicleCheckListDescription { get; set; }

        /// <summary>
        /// Is Interior
        /// </summary>
        public bool IsInterior { get; set; }

        /// <summary>
        /// Vehicle Check List Key
        /// </summary>
        public short? VehicleCheckListKey { get; set; }
    }
}