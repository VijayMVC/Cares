using Cares.Models.DomainModels;
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
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OccupationTypeDropDown CreateFrom(this OccupationType source)
        {
            return new ApiModel.OccupationTypeDropDown
                   {
                       OccupationTypeId = source.OccupationTypeId,
                       OccupationTypeCodeName = source.OccupationTypeCode + " - " + source.OccupationTypeName
                   };
        }

        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static OccupationType CreateFrom(this ApiModel.OccupationTypeDropDown source)
        {
            return new OccupationType
            {
                OccupationTypeId = source.OccupationTypeId,
                OccupationTypeName = source.OccupationTypeCodeName,
            };
        }

        #endregion
        #endregion
    }
}