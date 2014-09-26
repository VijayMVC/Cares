using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Ra Vehicle Check List repository interface
    /// </summary>
    public interface IRaVehicleCheckListRepository : IBaseRepository<RaVehicleCheckList, long>
    {
        /// <summary>
        /// Association check Ra Vehicle Check List with  Vehicle CheckList
        /// </summary>
        bool IsRaVehicleCheckListAssociatedWithVehicleCheckList(long vehicleCheckListId);

    }
}
