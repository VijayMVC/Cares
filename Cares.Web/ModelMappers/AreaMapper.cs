using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class AreaMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static ApiModel.Area CreateFrom(this Area source)
        {
            return new ApiModel.Area()
            {
                AreaId = source.AreaId,
                AreaCustomId = source.AreaId.ToString()+"-"+source.AreaCode+"-"+source.AreaName,
                AreaCode = source.AreaCode,
                AreaName = source.AreaName,
                CityId = source.CityId
            };
        }
        #endregion        
        #endregion
    }
}