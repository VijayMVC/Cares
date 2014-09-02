using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Repository Interface
    /// </summary>
    public interface IVehicleRepository : IBaseRepository<Vehicle, long>
    {

        /// <summary>
        /// Get Vechile against HireGroup
        /// </summary>
        GetVehicleResponse GetByHireGroup(VehicleSearchRequest request);

        /// <summary>
        /// Get Vehicle List Based On Search Criteria
        /// </summary>
        GetVehicleResponse GetVehicles(VehicleSearchRequest request);

        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(Vehicle vehicle);
    }
}






