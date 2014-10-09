
namespace Cares.Web.Models
{
    /// <summary>
    /// Maintenance Type Group web model
    /// </summary>
    public class MaintenanceTypeGroup
    {
        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Group Code
        /// </summary>
        public string MaintenanceTypeGroupCode { get; set; }

        /// <summary>
        /// Maintenance Type Group Name
        /// </summary>
        public string MaintenanceTypeGroupName { get; set; }

        /// <summary>
        ///Maintenance Type Group Description
        /// </summary>
        public string MaintenanceTypeGroupDescription { get; set; }
    }
}