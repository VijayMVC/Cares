using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// PhoneType Mapper
    /// </summary>
    public static class PhoneTypeMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.PhoneType CreateFrom(this DomainModel.PhoneType source)
            {
                return new ApiModel.PhoneType()
                {
                    PhoneTypeId = source.PhoneTypeId,
                    PhoneTypeName = source.PhoneTypeCode + '-'+source.PhoneTypeName,
                    PhoneTypeCustomId = source.PhoneTypeId.ToString() + '-'+ source.PhoneTypeCode + '-' + source.PhoneTypeName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.PhoneType CreateFrom(this ApiModel.PhoneType source)
        {
            return new DomainModel.PhoneType()
            {
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeName = source.PhoneTypeName
            };
        }
        
        #endregion
        #endregion
    }
}