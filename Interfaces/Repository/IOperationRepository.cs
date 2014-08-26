using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

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
        ICollection<Operation> GetSalesOperation();

        /// <summary>
        /// Get Operation With Details 
        /// </summary>
        Operation GetOperationWithDetails(long id);

        /// <summary>
        /// Search Operation
        /// </summary>
        IEnumerable<Operation> SearchOperation(OperationSearchRequest request, out int rowCount);

        /// <summary>
        /// Operation Code validation 
        /// </summary>
        bool IsOperationCodeExists(Operation operation);
    }
}
