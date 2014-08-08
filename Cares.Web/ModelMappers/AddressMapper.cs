using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Address Mapper
    /// </summary>
    public static class AddressMapper
    {
        #region Public
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Address CreateFrom(this ApiModel.Address source)
        {
            return new Address
            {
                AddressId = source.AddressId != null ? (long)source.AddressId : 0,
                ContactPerson = source.ContactPerson,
                StreetAddress = source.StreetAddress,
                EmailAddress = source.EmailAddress,
                WebPage = source.WebPage,
                ZipCode = source.ZipCode,
                POBox = source.POBox,
                CountryId = source.CountryId,
                AddressTypeId = source.AddressTypeId,      
                BusinessPartnerId = source.BusinessPartnerId
            };
        }
        /// <summary>
        ///  Create Web Api model from domain model
        /// </summary>
        public static ApiModel.Address CreateFrom(this Address source)
        {
            return new ApiModel.Address
            {
                AddressId = source.AddressId,
                ContactPerson = source.ContactPerson,
                StreetAddress = source.StreetAddress,
                EmailAddress = source.EmailAddress,
                WebPage = source.WebPage,
                ZipCode = source.ZipCode,
                POBox = source.POBox,
                CountryId = source.CountryId,
                AddressTypeId = source.AddressTypeId,      
                //PhoneTypeName = source.PhoneType != null ? (source.PhoneType.PhoneTypeCode + '-' + source.PhoneType.PhoneTypeName) : string.Empty,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }
        #endregion
    }
}