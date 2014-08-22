using System;
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
        /// Get Fleet pool with reference data details
        /// </summary>
        FleetPool GetFleetPoolWithDetails(long id);

        /// <summary>
        /// Fleet Pool  Code Check
        /// </summary>
        bool IsFleetPoolCodeExists(FleetPool fleetPool);
    }
}
