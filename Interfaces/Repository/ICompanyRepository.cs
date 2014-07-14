using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Company Repository Interface
    /// </summary>
    public interface ICompanyRepository : IBaseRepository<Company, int>
    {

    }
}
