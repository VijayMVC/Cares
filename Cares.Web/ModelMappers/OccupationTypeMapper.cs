using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Occupation Type Mapper
    /// </summary>
    public static class OccupationTypeMapper
    {
        #region Public
        #region Entity To Model

        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static ApiModel.OccupationTypeDropDown CreateFrom(this OccupationType source)
        {
            return new ApiModel.OccupationTypeDropDown
                   {
                       OccupationTypeId = source.OccupationTypeId,
                       OccupationTypeCodeName = source.OccupationTypeCode + " - " + source.OccupationTypeName
                   };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OccupationType CreateFromm(this OccupationType source)
        {
            return new ApiModel.OccupationType
            {
                OccupationTypeId = source.OccupationTypeId,
                OccupationTypeCode = source.OccupationTypeCode,
                OccupationTypeName = source.OccupationTypeName,
                OccupationTypeDescription = source.OccupationTypeDescription
            };
        }

        /// <summary>
        ///  Create web search response form domain search response
        /// </summary>
        public static ApiModel.OccupationTypeSearchRequestResponse CreateFromm(this OccupationTypeSearchRequestResponse source)
        {
            return new ApiModel.OccupationTypeSearchRequestResponse
            {
               OccupationTypes = source.OccupationTypes.Select(occupationType => occupationType.CreateFromm())
            };
        }

        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model [dropdown]
        /// </summary>
        public static OccupationType CreateFrom(this ApiModel.OccupationTypeDropDown source)
        {
            return new OccupationType
            {
                OccupationTypeId = source.OccupationTypeId,
                OccupationTypeName = source.OccupationTypeCodeName,
            };
        }

        /// <summary>
        ///  Create domain model from web
        /// </summary>
        public static OccupationType CreateFromm(this ApiModel.OccupationType source)
        {
            return new OccupationType
            {
                OccupationTypeId = source.OccupationTypeId,
                OccupationTypeCode = source.OccupationTypeCode,
                OccupationTypeName = source.OccupationTypeName,
                OccupationTypeDescription = source.OccupationTypeDescription
            };
        }

        #endregion
        #endregion
    }
}