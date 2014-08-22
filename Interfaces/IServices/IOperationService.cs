using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Operation Service Interface
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// Get All Opertaions
        /// </summary>
        IEnumerable<Operation> LoadAll();

        OperationBaseDataResponse LoadOperationBaseData();

        OperationSearchResponse SearchOperation(OperationSearchRequest request);

        void DeleteOperation(Operation operationobeDeleted);

        Operation SaveOperation(Operation operation);

    }
}
