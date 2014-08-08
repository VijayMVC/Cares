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
        public static ApiModel.PhoneType CreateFrom(this PhoneType source)
            {
                return new ApiModel.PhoneType
                {
                    PhoneTypeId = source.PhoneTypeId,
                    PhoneTypeName = source.PhoneTypeCode + '-'+source.PhoneTypeName,
                    PhoneTypeCustomId = source.PhoneTypeId.ToString(CultureInfo.InvariantCulture) + '-'+ source.PhoneTypeCode + '-' + source.PhoneTypeName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static PhoneType CreateFrom(this ApiModel.PhoneType source)
        {
            return new PhoneType
            {
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeName = source.PhoneTypeName
            };
        }
        
        #endregion       
    }
}