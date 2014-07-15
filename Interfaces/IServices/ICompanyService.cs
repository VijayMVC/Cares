

using System.Collections.Generic;
using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Company Service Interface
    /// </summary>
    public interface ICompanyService
    {
        IQueryable<Company> LoadAll();
    }
}
