using System.Linq;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// City Repository Interface
    /// </summary>
    public interface ICityRepository : IBaseRepository<City, int>
    {
        /// <summary>
        /// Get Cities by Country 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        IQueryable<City> GetCitiesByCountry(int countryId);
    }
}
