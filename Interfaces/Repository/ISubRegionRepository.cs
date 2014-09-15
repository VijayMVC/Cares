using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Sub Region Repository Interface
    /// </summary>
    public interface ISubRegionRepository : IBaseRepository<SubRegion, int>
    {
        /// <summary>
        /// Search Sub Region
        /// </summary>
        IEnumerable<SubRegion> SearchSubRegion(SubRegionSearchRequest request, out int rowCount);

        /// <summary>
        /// To check the association of region and sub region
        /// </summary>
        bool IsRegionAssocistedWithSubRegion(long regionId);

        /// <summary>
        /// Sub Region code duplication check
        /// </summary>
        bool DoesSubRegionCodeExist(SubRegion subRegion);

        /// <summary>
        /// Get Sub Region with detail by id
        /// </summary>
        SubRegion LoadSubRegionWithDetail(long subRegionId);
    }
}
