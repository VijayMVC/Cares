using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Segment Mapper
    /// </summary>
    public static class BusinessSegmentMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessSegment CreateFrom(this BusinessSegment source)
            {
                return new ApiModel.BusinessSegment
                {
                    BusinessSegmentId = source.BusinessSegmentId,
                    BusinessSegmentCode = source.BusinessSegmentCode,
                    BusinessSegmentName = source.BusinessSegmentName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessSegment CreateFrom(this ApiModel.BusinessSegment source)
        {
            return new BusinessSegment
            {
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentCode = source.BusinessSegmentCode,
                BusinessSegmentName = source.BusinessSegmentName
            };
        }
        
        #endregion
        #endregion
    }
}