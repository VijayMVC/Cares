using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class RegionMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.Region CreateFrom(this Region source)
        {
            return new ApiModel.Region
            {
                RegionId = source.RegionId,
                RegionCode = source.RegionCode,
                RegionName = source.RegionName,
                Country = source.Country != null ? source.Country.CountryCode + " - " + source.Country.CountryName : string.Empty,
                CountryId = source.CountryId
            };
        }
        #endregion        
        #endregion
    }
}