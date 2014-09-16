using System.Globalization;
using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;


namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// PhoneType Mapper
    /// </summary>
    public static class PhoneTypeMapper
    {
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.PhoneTypeDropDown CreateFrom(this PhoneType source)
        {
            return new ApiModel.PhoneTypeDropDown
            {
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeCodeName = source.PhoneTypeCode + " - " + source.PhoneTypeName,
            };
        }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static PhoneType CreateFrom(this ApiModel.PhoneTypeDropDown source)
        {
            return new PhoneType
            {
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeName = source.PhoneTypeCodeName
            };
        }

        #endregion
    }
}