
using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Rating Type Mapper model
    /// </summary>
    public  static class RatingTypeMapper
    {
        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.RatingTypeSearchRequestResponse CreateFrom(this RatingTypeSearchRequestResponse source)
        {
            return new Models.RatingTypeSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                RatingTypes = source.RatingTypes.Select(city => city.CreateBpRatingTypeFrom())
            };
        }
        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static BpRatingType CreateFrom(this Models.BpRatingType source)
        {
            return new BpRatingType
            {
                BpRatingTypeId = source.BpRatingTypeId,
                BpRatingTypeCode = source.BpRatingTypeCode,
                BpRatingTypeName = source.BpRatingTypeName,
                BpRatingTypeDescription = source.BpRatingTypeDescription
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.BpRatingType CreateBpRatingTypeFrom(this BpRatingType source)
        {
            return new Models.BpRatingType
            {
                BpRatingTypeId = source.BpRatingTypeId,
                BpRatingTypeCode = source.BpRatingTypeCode,
                BpRatingTypeName = source.BpRatingTypeName,
                BpRatingTypeDescription = source.BpRatingTypeDescription
            };
        }
    }
}