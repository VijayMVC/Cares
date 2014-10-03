using System.Linq;
using Cares.Models.ResponseModels;
using ApiModels = Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tarrif Type Response Mapper
    /// </summary>
    public static class TarrifTypeResponseMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TariffTypeSearchResponse CreateFrom(this TariffTypeResponse source)
        {
            return new ApiModels.TariffTypeSearchResponse
            {
                TotalCount = source.TotalCount,
                ServertariffTypes = source.TariffTypes.Select(p => p.CreateFrom())
            };

        }
        #endregion

    }
}