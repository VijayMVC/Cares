using System.Collections.Generic;
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
        /// <summary>
        /// Get Hire Group Details For Tariff Rate
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <returns></returns>
        HireGroupDetailResponse GetHireGroupDetailsForTariffRate(long standardRtMainId);
        /// <summary> 
        /// Find Standard Rate Main By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StandardRateMain Find(long id);
        /// <summary>
        /// Delete Standard Rate Main
        /// </summary>
        /// <param name="standardRateMain"></param>
        void DeleteTariffRate(StandardRateMain standardRateMain);
        /// <summary>
        /// Add Standard Rate Main
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        TariffRateContent AddTariffRate(StandardRateMain standardRateMain);
        /// <summary>
        /// Update Standard Rate Main
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        TariffRateContent Update(StandardRateMain standardRateMain);
        /// <summary>
        /// Add Standard Rate Against Standard Rate Main
        /// </summary>
        /// <param name="standardRate"></param>
        void AddStandardRate(StandardRate standardRate);
        /// <summary>
        /// Find Standard Rate 
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        IEnumerable<StandardRate> FindStandardRate(long standardRtMainId, long hireGroupDetailId);
    }
}
