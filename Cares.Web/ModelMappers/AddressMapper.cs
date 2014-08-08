using System.Linq;
using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;
using ResponseModel = Cares.Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Address Mapper
    /// </summary>
    public static class AddressMapper
    {
        #region Public

        #region Address

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

        #region Address Base Date Response Mapper

        /// <summary>
        ///  Create web api model from domain model
        /// </summary>
        public static ApiModel.AddressBaseResponse CreateFrom(this ResponseModel.AddressBaseDataResponse source)
        {
            return new ApiModel.AddressBaseResponse
            {
               ResponseCountry = source.ResponseCountry.CreateFrom(),
               ResponseRegions = source.ResponseRegions.Select(x=>x.CreateFrom()),
               ResponseSubRegions = source.ResponseSubRegions.Select(x=>x.CreateFrom()),
               ResponseCities = source.ResponseCities.Select(x=>x.CreateFrom()),
               ResponseAreas = source.ResponseAreas.Select(x=>x.CreateFrom()),
            };
        }
        #endregion

        #endregion
    }
}