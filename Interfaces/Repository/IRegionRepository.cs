using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Region Repository Interface
    /// </summary>
    public interface IRegionRepository : IBaseRepository<Region, int>
    {
        IEnumerable<Region> GetRegions(int id);
        /// <summary>
        /// Get Regions by Country Id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        IEnumerable<Region> GetRegionsByCountry(int countryId);
    }
}
