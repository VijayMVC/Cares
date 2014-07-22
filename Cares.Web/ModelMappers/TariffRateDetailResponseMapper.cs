using System.Linq;
using Cares.Web.Models;
using DomainResponseModels = Models.ResponseModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Rate Detail Response Mapper
    /// </summary>
    public static class TariffRateDetailResponseMapper
    {
        #region Public

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TariffRateDetailResponse CreateFrom(this DomainResponseModels.TariffRateDetailResponse source)
        {
            return new TariffRateDetailResponse
            {
                StandardRateMain = source.StandardRateMain.CreateFromForDetail(),
                HireGroupDetails = source.HireGroupDetails != null ? source.HireGroupDetails.Select(m => m.CreateFromForDetail()) : null

            };
        }

        #endregion
    }
}