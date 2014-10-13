using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;


namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Model Interface
    /// </summary>
    public interface IVehicleModelRepository : IBaseRepository<VehicleModel, long>
    {
        /// <summary>
        /// Search Vehicle Model
        /// </summary>
        IEnumerable<VehicleModel> SearchVehicleModel(VehicleModelSearcgRequest request, out int rowCount);

        /// <summary>
        /// Self code duplication check of Vehicle Model
        /// </summary>
        bool VehicleModelCodeDuplicationCheck(VehicleModel vehicleModel);

    }
}
