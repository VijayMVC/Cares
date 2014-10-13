using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Status Repository Interface
    /// </summary>
    public interface IVehicleStatusRepository : IBaseRepository<VehicleStatus, long>
    {
        /// <summary>
        /// SearchD Vehicle Statuse
        /// </summary>
        IEnumerable<VehicleStatus> SearchVehicleStatus(VehicleStatusSearchRequest request, out int rowCount);

        /// <summary>
        /// Vehicle Status Self code duplication check
        /// </summary>
        bool VehicleStatusCodeDuplicationCheck(VehicleStatus vehicleStatus);

    }
}
