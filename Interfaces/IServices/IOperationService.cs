using System.Collections.Generic;
using Cares.Models.DomainModels;

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
    }
}
