using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Type Base Response Mapper
    /// </summary>
    public static class RegionResponseMapper
    {
        #region Public

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static RegionResponse CreateFrom(this Cares.Models.ResponseModels.RegionResponse source)
        {
            return new RegionResponse()
            {
                ResponseRejions = source.Regions.Select(c => c.CreateFrom())
            };
        }

        #endregion
    }
}