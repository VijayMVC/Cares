
using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Operation Service Interface
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// Get All Opertaions
        /// </summary>
        /// <returns></returns>
        IEnumerable<Operation> LoadAll();
    }
}
