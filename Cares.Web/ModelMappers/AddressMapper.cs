using System.Linq;
using Cares.Models.DomainModels;
using Castle.Components.DictionaryAdapter.Xml;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Address Mapper
    /// </summary>
    public static class AddressMapper
    {
        #region Address

        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Address CreateFrom(this ApiModel.Address source)
        {
            if (source.CountryId != null)
                    return new Address
                    {
                        AddressId = source.AddressId != null ? (long) source.AddressId : 0,
                        ContactPerson = source.ContactPerson,
                        StreetAddress = source.StreetAddress,
                        EmailAddress = source.EmailAddress,
                        WebPage = source.WebPage,
                        ZipCode = source.ZipCode,
                        POBox = source.POBox,
                        CountryId = (short) source.CountryId,
                        RegionId = source.RegionId,
                        SubRegionId = source.SubRegionId,
                        CityId = source.CityId,
                        AreaId = source.AreaId,
                        AddressTypeId = source.AddressTypeId,
                        BusinessPartnerId =  source.BusinessPartnerId
                    };
            return new Address();
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
                CountryName = source.Country != null ? (source.Country.CountryCode + " - " + source.Country.CountryName) : string.Empty,
                RegionId = source.RegionId,
                RegionName =
                    source.Region != null ? (source.Region.RegionCode + " - " + source.Region.RegionName) : string.Empty,
                SubRegionId = source.SubRegionId,
                SubRegionName =
                    source.SubRegion != null
                        ? (source.SubRegion.SubRegionCode + " - " + source.SubRegion.SubRegionName)
                        : string.Empty,
                CityId = source.CityId,
                CityName = source.City != null ? (source.City.CityCode + " - " + source.City.CityName) : string.Empty,
                AreaId = source.AreaId,
                AreaName = source.Area != null ? (source.Area.AreaCode + " - " + source.Area.AreaName) : string.Empty,
                AddressTypeId = source.AddressTypeId,
                AddressTypeName = source.AddressType != null ? (source.AddressType.AddressTypeCode + " - " + source.AddressType.AddressTypeName) : string.Empty,
            };

            #endregion
        }


        public static ApiModel.AddressBaseResponse CreateFrom(this Cares.Models.ResponseModels.AddressBaseDataResponse source)
        {
            return new ApiModel.AddressBaseResponse
            {
                ResponseCountry=source.ResponseCountry.CreateFrom(),
                ResponseCities = source.ResponseCities.Select(city => city.CreateFrom()),
                ResponseAreas = source.ResponseAreas.Select(area => area.CreateFrom()),
                ResponseRegions = source.ResponseRegions.Select(region => region.CreateFrom()),
                ResponseSubRegions = source.ResponseSubRegions.Select(subregion => subregion.CreateFrom())
            };
        }
    }
}