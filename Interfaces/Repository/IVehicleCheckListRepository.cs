using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Check List Repository Interface
    /// </summary>
    public interface IVehicleCheckListRepository : IBaseRepository<VehicleCheckList, long>
    {
        /// <summary>
        /// Search Vehicle CheckList
        /// </summary>
        IEnumerable<VehicleCheckList> SearchVehicleCheckList(VehicleCheckListSearchRequest request, out int rowCount);

        /// <summary>
        /// sel-Code duplication check
        /// </summary>
        bool DoesVehicleCheckListCodeExist(VehicleCheckList vehicleCheckList);
    }
}
