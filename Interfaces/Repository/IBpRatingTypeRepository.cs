using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Rating Type Repository Interface
    /// </summary>
    public interface IBpRatingTypeRepository : IBaseRepository<BpRatingType, long>
    {
        /// <summary>
        /// Search Rating Type
        /// </summary>
        IEnumerable<BpRatingType> SearchRatingType(RatingTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// seld-code duplication check
        /// </summary>
        bool DoesRatingTypeCodeExist(BpRatingType raringType);

    }
}
