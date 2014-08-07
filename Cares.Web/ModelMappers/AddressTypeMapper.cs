using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Address Type Mapper
    /// </summary>
    public static class AddressTypeMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web Api model from domain entity
        /// </summary>
        public static ApiModel.AddressType CreateFrom(this DomainModel.AddressType source)
            {
                return new ApiModel.AddressType()
                {
                    AddressTypeId = source.AddressTypeId,
                    AddressTypeName = source.AddressTypeCode + '-'+source.AddressTypeName,
                    AddressTypeCustomId = source.AddressTypeId.ToString() + '-'+ source.AddressTypeCode + '-' + source.AddressTypeName
                };
            }
        #endregion
        #endregion
    }
}