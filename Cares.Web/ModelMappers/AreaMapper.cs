using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class AreaMapper
    {
        /// <summary>
        ///  Create web api model from domain entity [dropdown]
        /// </summary>
        public static ApiModel.AreaDropDown CreateFrom(this Area source)
        {
            return new ApiModel.AreaDropDown()
            {
                AreaId = source.AreaId,
                AreaCodeName = source.AreaCode + " - "+source.AreaName,
                CityId = source.CityId
            };
        }

        /// <summary>
        ///  Create base data response web api model from domain base data response
        /// </summary>
        public static ApiModel.AreaBaseDataResponse CreateFrom(this AreaBaseDataResponse source)
        {
            return new ApiModel.AreaBaseDataResponse()
            {
                Cities = source.Cities.Select(city => city.CreateFrom())
            };
        }

        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static ApiModel.AreaSearchRequestResponse CreateFrom(this Cares.Models.RequestModels.AreaSearchRequestResponse source)
        {
            return new ApiModel.AreaSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                Areas = source.Areas.Select(area => area.CreateFromm())
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
        public static ApiModel.Area CreateFromm( this Area source)
        {
            return new ApiModel.Area
            {
                AreaId = source.AreaId,
                AreaCode = source.AreaCode,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                CityId = source.CityId,
                CityName = source.City.CityName
            };
        }

        /// <summary>
        /// Create From Web model
        /// </summary>
        public static Area CreateFrom(this ApiModel.Area source)
        {
            return new Area
            {
                AreaId = source.AreaId,
                AreaCode = source.AreaCode,
                AreaName = source.AreaName,
                AreaDescription = source.AreaDescription,
                CityId = source.CityId,
            };
        }

    }
}