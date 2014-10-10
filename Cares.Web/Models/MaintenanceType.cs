
namespace Cares.Web.Models
{
    /// <summary>
    /// Maintenance Type web model
    /// </summary>
    public class MaintenanceType
    {
        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeId { get; set; }

        /// <summary>
        /// Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Group Name
        /// </summary>
        public string MaintenanceTypeGroupName { get; set; }

        /// <summary>
        /// Maintenance Type Code
        /// </summary>
        public string MaintenanceTypeCode { get; set; }

        /// <summary>
        /// Maintenance Type Name
        /// </summary>
        public string MaintenanceTypeName { get; set; }

        /// <summary>
        ///Maintenance Type Description
        /// </summary>
        public string MaintenanceTypeDescription { get; set; }
    }
}