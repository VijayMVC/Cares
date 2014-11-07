using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class CityMapper
    {
        #region City
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static ApiModel.CityDropDown CreateDropdownFrom(this City source)
        {
            return new ApiModel.CityDropDown
            {
                CityId = source.CityId,
                CityCodeName = source.CityCode + " - " + source.CityName,
                RegionId = source.RegionId,
                CountryId = source.CountryId,
                SubRegionId = source.SubRegionId
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.City CreateFrom(this City source)
        {
            return new ApiModel.City
            {
                CityId = source.CityId,
                CityCode = source.CityCode ,
                CityName = source.CityName,
                CityDescription = source.CityDescription,
                RegionId = source.RegionId,
                RegionName = source.RegionId!=null ? source.Region.RegionName : string.Empty,
                CountryId = source.CountryId,
                CountryName = source.Country.CountryName,
                SubRegionId = source.SubRegionId,
                SubRegionName = source.SubRegionId!=null ? source.SubRegion.SubRegionName: string.Empty

            };
        }

        /// <summary>
        /// create Base Data Response from doain model
        /// </summary>
        public static ApiModel.CityBaseDataResponse CreateFrom(this CityBaseDataResponse source)
        {
            return new ApiModel.CityBaseDataResponse
            {
                CountriyDropDowns = source.Countries.Select(country => country.CreateFrom()),
                RegionDropDowns = source.Regions.Select(region => region.CreateDropdownFrom()),
                SubRegionDowns = source.SubRegions.Select(subRegion => subRegion.CreateDropdownFrom())
            };
        }


        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static ApiModel.CitySearchRequestResponse CreateFrom(this CitySearchRequestResponse source)
        {
            return new ApiModel.CitySearchRequestResponse
            {
                TotalCount = source.TotalCount,
                Cities = source.Cities.Select(city => city.CreateFrom())
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static City CreateFrom(this ApiModel.City source)
        {
            return new City
            {
                CityId = source.CityId,
                CityCode = source.CityCode.Trim() ,
                CityName = source.CityName,
                CityDescription = source.CityDescription,
                RegionId = source.RegionId,
                CountryId = source.CountryId,
                SubRegionId = source.SubRegionId
            };
        }
        #endregion
        #endregion
    }
}