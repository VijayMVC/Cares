using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// OperationsWorkPlaces WorkPlace Repository Interface
    /// </summary>
    public interface IOperationsWorkPlaceRepository : IBaseRepository<OperationsWorkPlace, long>
    {
        /// <summary>
        /// Gets all operatoins workplaces for sale 
        /// </summary>
        /// <returns></returns>
        IEnumerable<OperationsWorkPlace> GetSalesOperationsWorkPlace();

        /// <summary>
        /// Get WorkPlace Operation By WorkPlace Id
        /// </summary>
        IEnumerable<OperationsWorkPlace> GetWorkPlaceOperationByWorkPlaceId(long workplaceId);

        /// <summary>
        /// Get Operation Work Place With Details
        /// </summary>
        OperationsWorkPlace GetOperationWorkPlaceWithDetails(long id);

        /// <summary>
        /// Get Operation Workplace by domainKey
        /// </summary>
        IEnumerable<OperationsWorkPlace> GetSalesBranchesByDomainKey(long domainKey);

        /// <summary>
        /// Association check b/n Operation Work Place and Fleet Pool
        /// </summary>
        bool IsOperationWorkPlaceAssociatedWithFleetPool(double fleetPollId);

        /// <summary>
        /// Get operation id by operatoin workplace id
        /// </summary>
        long GetOperationIdByOperationWorkPlaceId(long operationWorkPlaceId);

       
    }
}
 