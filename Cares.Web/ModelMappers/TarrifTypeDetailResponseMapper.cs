using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// TarrifType Detail Response Mapper
    /// </summary>
    public static class TarrifTypeDetailResponseMapper
    {
        #region Public

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TariffTypeDetailResponse CreateFrom(this Cares.Models.ResponseModels.TariffTypeDetailResponse source)
        {
            return new TariffTypeDetailResponse
            {
                TariffType = source.TariffType.CreateFromDetail(),
                TariffTypeRevisions = source.TariffTypeRevisions != null ? source.TariffTypeRevisions.Select(m => m.CreateFromDetail()) : null,
               
            };
        }

        #endregion
    }
}