using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class CityMapper
    {
        #region City
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.CityDropDown CreateFrom(this City source)
        {
            return new ApiModel.CityDropDown()
            {
                CityId = source.CityId,
                CityCodeName = source.CityCode + " - " + source.CityName,
                RegionId = source.RegionId,
                CountryId = source.CountryId,
                SubRegionId = source.SubRegionId
            };
        }
        #endregion
        #endregion
    }
}