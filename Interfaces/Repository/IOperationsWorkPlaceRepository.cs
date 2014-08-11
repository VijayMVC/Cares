using System.Collections.Generic;
using Cares.Models.DomainModels;

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
    }
}
