using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models.DomainModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Operation Repository Interface
    /// </summary>
    public interface IOperationRepository : IBaseRepository<Operation, long>
    {
        /// <summary>
        /// gets all operatoins for sale 
        /// </summary>
        /// <returns></returns>
        IQueryable<Operation> GetSalesOperation();
    }
}
