using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Check if sub region is asssociated with any city
        /// </summary>
        bool IsSubRegionAssociatedWithCity(long subRegionId);

        /// <summary>
        /// Search City
        /// </summary>
        IEnumerable<City> SearchCity(CitySearchRequest request, out int rowCount);

        /// <summary>
        /// city Code duplication check 
        /// </summary>
        bool DoesCityCodeExists(City city);

        /// <summary>
        /// Get City with detail
        /// </summary>
        City LoadCityWithDetail(long cityId);
    }
}

