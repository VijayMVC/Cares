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
        IQueryable<City> GetCitiesByCountry(int countryId);

        /// <summary>
        /// Check if region is asssociated with any city
        /// </summary>
        bool IsRegionAssociatedWithCity(long regionId);

    }
}
