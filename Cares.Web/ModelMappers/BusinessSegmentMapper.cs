using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

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
        public static ApiModel.BusinessSegmentDropDown CreateFrom(this BusinessSegment source)
        {
            return new ApiModel.BusinessSegmentDropDown
            {
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentCodeName = source.BusinessSegmentCode + " - " + source.BusinessSegmentName
            };
        }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessSegment CreateFrom(this ApiModel.BusinessSegmentDropDown source)
        {
            return new BusinessSegment
            {
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentName = source.BusinessSegmentCodeName
            };
        }

        #endregion
        #endregion
    }
}