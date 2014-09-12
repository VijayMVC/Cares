using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Region Repository Interface
    /// </summary>
    public interface IRegionRepository : IBaseRepository<Region, int>
    {
        /// <summary>
        /// Get All Regions
        /// </summary>
        IEnumerable<Region> GetRegions(int id);


        /// <summary>
        /// Get Regions by Country Id
        /// </summary>
        IEnumerable<Region> GetRegionsByCountry(int countryId);

        /// <summary>
        /// Search Region
        /// </summary>
        IEnumerable<Region> SearchRegion(RegionSearchRequest request, out int rowCount);

        /// <summary>
        /// Region code duplication check
        /// </summary>
        bool DoesRegionCodeExist(Region region);

        /// <summary>
        /// Get Region with detail
        /// </summary>
        Region LoadReionWithDetail(long regionId);
    }
}
