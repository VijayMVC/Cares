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
        FleetPool GetFleetPoolWithDetails(long fleetPoolId);

        /// <summary>
        /// Fleet Pool  Code Check
        /// </summary>
        bool IsFleetPoolCodeExists(FleetPool fleetPool);


        /// <summary>
        /// To chechk does operation contain any fleetpool
        /// </summary>
        bool IsOperationAssocisiatedWithAnyFleetPool(long operationId);

        /// <summary>
        /// Get total Count Of Fleet Pools With DomainKey
        /// </summary>
        int GetCountOfFleetPoolWithDomainKey();
    }
}
