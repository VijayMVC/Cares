using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class CityMapper
    {
        #region Public

        #region City
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.City CreateFrom(this City source)
        {
            return new ApiModel.City()
            {
                CityId = source.CityId,
                CityCustomId = source.CityId.ToString()+"-"+source.CityCode+"-"+source.CityName,
                CityCode = source.CityCode,
                CityName = source.CityName,
                RegionId = source.RegionId,
                CountryId = source.CountryId,
                SubRegionId = source.SubRegionId
            };
        }
        #endregion        
        #endregion
        
        #endregion
    }
}