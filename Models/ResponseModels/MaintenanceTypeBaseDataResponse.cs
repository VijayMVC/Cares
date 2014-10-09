using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Maintenance Typ eBase Data Response Domain model
    /// </summary>
    public class MaintenanceTypeBaseDataResponse
    {
        /// <summary>
        /// List of Maintenance Type Groups
        /// </summary>
        public IEnumerable<MaintenanceTypeGroup> MaintenanceTypeGroups { get; set; }
    }
}
