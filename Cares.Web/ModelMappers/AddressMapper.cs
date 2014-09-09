﻿using Cares.Models.DomainModels;
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
                    BusinessPartnerId = source.BusinessPartnerId
                };
            else return new Address();
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
                CountryName = (source.Country.CountryCode + "-" + source.Country.CountryName),
                RegionId = source.RegionId,
                RegionName =
                    source.RegionId != null ? (source.Region.RegionCode + "-" + source.Region.RegionName) : string.Empty,
                SubRegionId = source.SubRegionId,
                SubRegionName =
                    source.SubRegionId != null
                        ? (source.SubRegion.SubRegionCode + "-" + source.SubRegion.SubRegionName)
                        : string.Empty,
                CityId = source.CityId,
                CityName = source.CityId != null ? (source.City.CityCode + "-" + source.City.CityName) : string.Empty,
                AreaId = source.AreaId,
                AreaName = source.AreaId != null ? (source.Area.AreaCode + "-" + source.Area.AreaName) : string.Empty,
                AddressTypeId = source.AddressTypeId
            };

            #endregion
        }
    }
}