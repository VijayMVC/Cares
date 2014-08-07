using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// FleetPool Repository
    /// </summary>
    public interface IFleetPoolRepository:IBaseRepository<FleetPool, long>
    {
        /// <summary>
        /// Search Fleet Pool Request
        /// </summary>
        IEnumerable<FleetPool> SearchFleetPool(FleetPoolSearchRequest request, out int rowCount);
        /// <summary>
        /// Add new FleetPools
        /// </summary>
        FleetPool AddNewFleetPool(FleetPool request);
    }
}
