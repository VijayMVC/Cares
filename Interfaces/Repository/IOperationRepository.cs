using System.Linq;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
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
