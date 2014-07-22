using System.Linq;
using ApiModels = Cares.Web.Models;
using DomainModels = Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Rate Response Mapper
    /// </summary>
    public static class TariffRateResponseMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TariffRateResponse CreateFrom(this DomainModels.TariffRateResponse source)
        {
            return new ApiModels.TariffRateResponse
            {
                TotalCount = source.TotalCount,
                TariffRates = source.TariffRates.Select(p => p.CreateFrom())
            };

        }
        #endregion
    }
}