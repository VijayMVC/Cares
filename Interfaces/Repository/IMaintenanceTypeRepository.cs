using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Maintenance Type Repository Interface
    /// </summary>
    public interface IMaintenanceTypeRepository : IBaseRepository<MaintenanceType, long>
    {
        /// <summary>
        /// Association check b/w Maintenece Type Group and Maintenece Type
        /// </summary>
        bool IsMainteneceTypeGroupAssociatedWithMainteneceType(long mainteneceTypeGroupId);

        /// <summary>
        /// Search  Maintenance Type
        /// </summary>
        IEnumerable<MaintenanceType> SearchMaintenanceType(MaintenanceTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// MaintenanceType code duplication check
        /// </summary>
        bool MaintenanceTypeCodeDuplicationCheck(MaintenanceType maintenanceType);

        /// <summary>
        /// Load detail object of Maintenance Type
        /// </summary>
        MaintenanceType LoadMaintenanceTypeWithDetail(long maintenanceTypeId);
    }
}
