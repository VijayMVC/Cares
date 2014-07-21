using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Company Service Interface
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Load all companies
        /// </summary>
        /// <returns></returns>
        IQueryable<Company> LoadAll();
    }
}
