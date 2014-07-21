using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Country Service Interface
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Load all countries
        /// </summary>
        /// <returns></returns>
        IQueryable<Country> LoadAll();
    }
}
