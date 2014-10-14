using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Maintenece Type Group Search Request Response Domain mOdel
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
