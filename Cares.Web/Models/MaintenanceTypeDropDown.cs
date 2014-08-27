namespace Cares.Web.Models
{
    /// <summary>
    /// Maintenance Type Drop Down
    /// </summary>
    public sealed class MaintenanceTypeDropDown
    {
        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeId { get; set; }

        /// <summary>
        /// Maintenance Type Code Name
        /// </summary>
        public string MaintenanceTypeCodeName { get; set; }
    }
}