

using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Rating Type Service Interface
    /// </summary>
    public interface IRatingTypeService
    {

        /// <summary>
        /// Search Rating Type
        /// </summary>
        RatingTypeSearchRequestResponse SearchRatingType(RatingTypeSearchRequest request);

        /// <summary>
        /// Delete Rating Type by id
        /// </summary>
        void DeleteRatingType(long ratingTypeId);

        /// <summary>
        /// Add /Update Rating Type
        /// </summary>
        BpRatingType SaveRatingType(BpRatingType bpRatingType);

    }
}
