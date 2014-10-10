using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Maintenece Type Group Search Request Response Web Model
    /// </summary>
    public class MainteneceTypeGroupSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Maintenance Type Group List
        /// </summary>
        public IEnumerable<MaintenanceTypeGroup> MaintenanceTypeGroups { get; set; }

        /// <summary>
        /// Total Count of Maintenance Type Group
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}