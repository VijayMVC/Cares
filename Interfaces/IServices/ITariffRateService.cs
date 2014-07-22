using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Tariff Rate service interface
    /// </summary>
    public interface ITariffRateService
    {
        /// <summary>
        /// Get All Base Data
        /// </summary>
        /// <returns></returns>
        TariffRateBaseResponse GetBaseData();
        TariffRateResponse LoadTariffRates(TariffRateRequest tariffRateRequest);
    }
}
