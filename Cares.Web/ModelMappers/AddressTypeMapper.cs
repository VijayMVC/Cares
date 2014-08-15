using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Address Type Mapper
    /// </summary>
    public static class AddressTypeMapper
    {
        #region Entity To Model
        /// <summary>
        ///  Create web Api model from domain entity
        /// </summary>
        public static ApiModel.AddressTypeDropDown CreateFrom(this DomainModel.AddressType source)
        {
            return new ApiModel.AddressTypeDropDown()
            {
                AddressTypeId = source.AddressTypeId,
                AddressTypeCodeName = source.AddressTypeCode + " - " + source.AddressTypeName,
            };
        }
        #endregion
    }
}