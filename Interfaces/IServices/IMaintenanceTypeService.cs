using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Maintenance Type Service Interface
    /// </summary>
    public interface IMaintenanceTypeService
    {
        /// <summary>
        /// Load all Maintenance Types
        /// </summary>
        IEnumerable<MaintenanceType> LoadAll();

        /// <summary>
        /// Delete Maintenance Type
        /// </summary>
        void DeleteMaintenanceType(long maintenanceTypeId);

        /// <summary>
        /// Load Base data of Maintenance Type
        /// </summary>
        MaintenanceTypeBaseDataResponse LoadMaintenanceTypeBaseData();

        /// <summary>
        /// Search Maintenance Type
        /// </summary>
        MaintenanceTypeSearchRequestResponse SearchMaintenanceType(MaintenanceTypeSearchRequest request);

        /// <summary>
        /// Add / Update  Maintenance Type
        /// </summary>
        MaintenanceType AddUpdateMaintenanceType(MaintenanceType maintenanceType);
    }
}
