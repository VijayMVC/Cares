using System.Security.Cryptography.X509Certificates;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Country Repository Interface
    /// </summary>
    public interface ICountryRepository : IBaseRepository<Country, int>
    {

    }
}
