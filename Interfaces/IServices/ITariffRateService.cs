using Models.DomainModels;
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
        /// <summary>
        /// Load Tariff Rates
        /// </summary>
        /// <param name="tariffRateRequest"></param>
        /// <returns></returns>
        TariffRateResponse LoadTariffRates(TariffRateRequest tariffRateRequest);
        TariffRateDetailResponse FindTariffRateById(TariffRateDetailRequest tariffRateDetailRequest);
        StandardRateMain Find(long id);
        void DeleteTariffRate(StandardRateMain standardRateMain);
        StandardRateMain AddTariffRate(StandardRateMain standardRateMain);
        StandardRateMain Update(StandardRateMain standardRateMain);
    }
}
