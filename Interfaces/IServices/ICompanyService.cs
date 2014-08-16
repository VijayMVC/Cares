using System.Collections.Generic;
using System.Linq;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Company Service Interface
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Load all companies
        /// </summary>
        IEnumerable<Company> LoadAll();
    }
}
