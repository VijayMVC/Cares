using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class RegionMapper
    {
        #region Public

        #region Region
        #region Entity To Model
        /// <summary>
        ///  Create web dropdoen model from entity
        /// </summary>
        public static ApiModel.RegionDropDown CreateFrom(this Region source)
        {
            return new ApiModel.RegionDropDown
            {
                RegionId = source.RegionId,
                RegionCodeName = source.RegionCode +" - "+ source.RegionName,
                Country = source.Country != null ? source.Country.CountryCode + " - " + source.Country.CountryName : string.Empty,
                CountryId = source.CountryId
            };
        }


        /// <summary>
        /// Crete From Domain base data model 
        /// </summary>
        public static ApiModel.RegionBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.RegionBaseDataResponse source)
        {
            return new ApiModel.RegionBaseDataResponse
            {
                Countries = source.Countries.Select(country => country.CreateFrom())
            };
        }


        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static ApiModel.Region CreateFromm(this Region source)
        {
            return new ApiModel.Region
            {
                RegionId = source.RegionId,
                RegionCode = source.RegionCode,
                RegionName = source.RegionName,
                RegionDescription = source.RegionDescription,
                CountryId = source.CountryId,
                CountryName = source.Country.CountryCode+"-"+source.Country.CountryName
            };
        }

        /// <summary>
        ///  Create from web model
        /// </summary>
        public static Region CreateFrom(this ApiModel.Region source)
        {
            return new Region
            {
                RegionId = source.RegionId,
                RegionCode = source.RegionCode.Trim(),
                RegionName = source.RegionName,
                RegionDescription = source.RegionDescription,
                CountryId = source.CountryId,
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static ApiModel.RegionSearchRequestResponse CreateFrom(this RegionSearchRequestResponse source)
        {
            return new ApiModel.RegionSearchRequestResponse
            {
                Regions = source.Regions.Select(region => region.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        #endregion        
        #endregion
        #region Sub Region
        #region Entity To Model
        /// <summary>
        ///  Create web model[DropDown] from entity
        /// </summary>
        public static ApiModel.SubRegionDropDown CreateFrom(this SubRegion source)
        {
            return new ApiModel.SubRegionDropDown
            {
                SubRegionId = source.SubRegionId,
                SubRegionCodeName = source.SubRegionCode+" - "+source.SubRegionName,
                RegionId = source.RegionId
            };
        }


        /// <summary>
        /// Crete From Domain base data model 
        /// </summary>
        public static ApiModel.SubRegionBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.SubRegionBaseDataResponse source)
        {
            return new ApiModel.SubRegionBaseDataResponse
            {
                RegionsDropDowns = source.Regions.Select(region => region.CreateFrom())
            };
        }


        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static ApiModel.SubRegionSearchRequestResponse CreateFrom(this SubRegionSearchRequestResponse source)
        {
            return new ApiModel.SubRegionSearchRequestResponse
            {
                SubRegions = source.SubRegions.Select(region => region.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static ApiModel.SubRegion CreateFromm(this SubRegion source)
        {
            return new ApiModel.SubRegion
            {
                SubRegionId = source.SubRegionId,
                SubRegionCode = source.SubRegionCode,
                SubRegionName = source.SubRegionName,
                SubRegionDescription = source.SubRegionDescription,

                RegionId = source.RegionId,
                RegionName = source.Region.RegionName
            };
        }


        /// <summary>
        ///  Create from web model 
        /// </summary>
        public static SubRegion CreateFrom(this ApiModel.SubRegion source)
        {
            return new SubRegion
            {
                SubRegionId = source.SubRegionId,
                SubRegionCode = source.SubRegionCode.Trim(),
                SubRegionName = source.SubRegionName,
                SubRegionDescription = source.SubRegionDescription,
                RegionId = source.RegionId
            };
        }
        #endregion
        #endregion

        #endregion
    }
}