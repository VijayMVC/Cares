using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Check List Item Repository Interface
    /// </summary>
    public interface IVehicleCheckListItemRepository : IBaseRepository<VehicleCheckListItem, long>
    {
        /// <summary>
        /// Association check Vehicle CheckList Item with  Vehicle CheckList
        /// </summary>
        bool IsVehicleCheckListItemAssociatedWithVehicleCheckList(long vehicleCheckListId);
    }
}
