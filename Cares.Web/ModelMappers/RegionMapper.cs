using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class RegionMapper
    {
        #region Public

        #region Region
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
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
        #endregion        
        #endregion

        #region Sub Region
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.SubRegionDropDown CreateFrom(this SubRegion source)
        {
            return new ApiModel.SubRegionDropDown()
            {
                SubRegionId = source.SubRegionId,
                SubRegionCodeName = source.SubRegionCode+" - "+source.SubRegionName,
                RegionId = source.RegionId
            };
        }
        #endregion
        #endregion
        
        #endregion
    }
}