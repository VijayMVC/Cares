﻿using System.Linq;
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
                RegionId = source.RegionId,
                SubRegionId = source.SubRegionId,
                CityId = source.CityId,
                AreaId = source.AreaId,
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
                CountryName = source.Country != null ? (source.Country.CountryCode +"-"+source.Country.CountryName) : string.Empty,
                RegionId = source.RegionId,
                RegionName = source.Region != null ? (source.Region.RegionCode +"-"+source.Region.RegionName) : string.Empty,
                SubRegionId = source.SubRegionId,
                SubRegionName = source.SubRegion != null ?(source.SubRegion.SubRegionCode + "-"+source.SubRegion.SubRegionName) : string.Empty,
                CityId = source.CityId,
                CityName = source.City != null ? (source.City.CityCode + "-"+source.City.CityName) : string.Empty,
                AreaId = source.AreaId,
                AreaName = source.Area != null ? (source.Area.AreaCode +"-"+source.Area.AreaName) : string.Empty,
                AddressTypeId = source.AddressTypeId,      
                AddressTypeName = source.AddressType != null ? (source.AddressType.AddressTypeCode + "-" + source.AddressType.AddressTypeName) : string.Empty,
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
    }
}