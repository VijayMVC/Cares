using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using System;

namespace Interfaces.IServices
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
    }
}
