using ApiModel = Cares.Web.Models;
using Models.DomainModels;
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
            return new ApiModel.Region()
            {
                RegionId = source.RegionId,
                RegionCode = source.RegionCode,
                RegionName = source.RegionName
            };
        }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Region CreateFrom(this ApiModel.Region source)
        {
            return new Region
            {
                RegionId = source.RegionId,
                RegionCode = source.RegionCode,
                RegionName = source.RegionName
            };
        }

        #endregion
        #endregion
    }
}