using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

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
        ICollection<Operation> GetSalesOperation();

        Operation GetCompanyWithDetails(long id);
        IEnumerable<Operation> SearchOperation(OperationSearchRequest request, out int rowCount);

    }
}
