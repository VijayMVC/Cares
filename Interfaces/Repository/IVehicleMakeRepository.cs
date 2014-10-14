using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Make Interface
    /// </summary>
    public interface IVehicleMakeRepository : IBaseRepository<VehicleMake, long>
    {
        /// <summary>
        /// Search Vehicle Make
        /// </summary>
        IEnumerable<VehicleMake> SearchVehicleMake(VehicleMakeSearchRequest request, out int rowCount);

        /// <summary>
        /// Vehicle Make Self code duplication check
        /// </summary>
        bool VehicleMakeCodeDuplicationCheck(VehicleMake vehicleMake);

    }
}
