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
        public static ApiModels.TarrifTypeResponse CreateFrom(this TarrifTypeResponse source)
        {
            return new ApiModels.TarrifTypeResponse
            {
                TotalCount = source.TotalCount,
                ServerTarrifTypes = source.TarrifTypes.Select(p => p.CreateFrom())
            };

        }
        #endregion

    }
}