using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

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


    }
}
 