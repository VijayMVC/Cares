using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// FleetPool Interface
    /// </summary>
    public interface IFleetPoolService
    {
        /// <summary>
        /// Load All FleetPools
        /// </summary>
        FleetPoolResponse SerchFleetPool(FleetPoolSearchRequest searchRequest);
        /// <summary>
        /// Load Fleet Pool Base Data
        /// </summary>
        FleetPoolBaseDataResponse LoadFleetPoolBaseData();
        /// <summary>
        /// Dalete Fleet Pool
        /// </summary>
        void DeleteFleetPool(int id);
        /// <summary>
        /// Add new FleetPools
        /// </summary>
        FleetPool AddNewFleetPool(FleetPool fleetPool);
        /// <summary>
        /// update fleetpool 
        /// </summary>
        FleetPool UpdateFleetPool(FleetPool request);
    }
}
