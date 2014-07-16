using System.Collections.Generic;
using Models.DomainModels;
using Models.RequestModels;

namespace Interfaces.Repository
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
    }
}
