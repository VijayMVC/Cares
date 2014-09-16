using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
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

        /// <summary>
        /// create from domain search request response model
        /// </summary>
        public static Models.BusinessSegmentSearchRequestResponse CreateFrom(this BusinessSegmentSearchRequestResponse source)
        {
            return new Models.BusinessSegmentSearchRequestResponse
            {
                BusinessSegments = source.BusinessSegments.Select(bSeg => bSeg.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create from domain model
        /// </summary>
        public static ApiModel.BusinessSegment CreateFromm(this BusinessSegment source)
        {
            return new ApiModel.BusinessSegment
            {
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentCode = source.BusinessSegmentCode,
                BusinessSegmentName = source.BusinessSegmentName,
                BusinessSegmentDescription = source.BusinessSegmentDescription,
            };
        }


        /// <summary>
        /// Create from web model
        /// </summary>
        public static  BusinessSegment CreateFrom(this ApiModel.BusinessSegment source)
        {
            return new BusinessSegment
            {
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentCode = source.BusinessSegmentCode,
                BusinessSegmentName = source.BusinessSegmentName,
                BusinessSegmentDescription = source.BusinessSegmentDescription,
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