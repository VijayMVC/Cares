using System.Linq;
using Cares.Web.Models;
using DomainResponseModels = Models.ResponseModels;
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
        public static RegionResponse CreateFrom(this DomainResponseModels.RegionResponse source)
        {
            return new RegionResponse()
            {
                ResponseRejions = source.Regions.Select(c => c.CreateFrom())
            };
        }

        #endregion
    }
}