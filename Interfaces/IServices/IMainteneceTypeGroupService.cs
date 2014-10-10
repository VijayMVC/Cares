
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Maintenece Type Group Service Interface
    /// </summary>
    public interface IMainteneceTypeGroupService
    {

        // <summary>
        // Search Maintenece Type Group
        // </summary>
        MainteneceTypeGroupSearchRequestResponse SearchMainteneceTypeGroup(MainteneceTypeGroupSearchRequest request);

        // <summary>
        // Delete Maintenece Type Group by id
        // </summary>
        void DeleteMainteneceTypeGroup(long mainteneceTypeGroupId);

        // <summary>
        // Add /Update Maintenece Type Group
        // </summary>
        MaintenanceTypeGroup SaveMaintenanceTypeGroup(MaintenanceTypeGroup maintenanceTypeGroup);

    }
}
