using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Maintenance Type Group Repository interface
    /// </summary>
    public interface IMainteneceTypeGroupRepository : IBaseRepository<MaintenanceTypeGroup, long>
    {
        
        /// <summary>
        /// Search Maintenece Type Group
        /// </summary>
        IEnumerable<MaintenanceTypeGroup> SearchMainteneceTypeGroup(MainteneceTypeGroupSearchRequest request, out int rowCount);


        /// <summary>
        /// Self-code duplication check
        /// </summary>
        bool IsMaintenanceTypeGroupCodeExist(MaintenanceTypeGroup maintenanceTypeGroup);
    }
}
