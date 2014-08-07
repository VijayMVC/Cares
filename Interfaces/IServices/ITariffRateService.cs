using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Tariff Rate service interface
    /// </summary>
    public interface ITariffRateService
    {
        /// <summary>
        /// Get Base Data
        /// </summary>
        TariffRateBaseResponse GetBaseData();
        /// <summary>
        /// Load Tariff Rates
        /// </summary>
        TariffRateResponse LoadTariffRates(TariffRateRequest tariffRateRequest);
        /// <summary>
        /// Get Hire Group Details For Tariff Rate
        /// </summary>
        HireGroupDetailResponse GetHireGroupDetailsForTariffRate(long standardRtMainId);
        /// <summary> 
        /// Find Standard Rate Main By ID
        /// </summary>
        StandardRateMain Find(long id);
        /// <summary>
        /// Delete Standard Rate Main
        /// </summary>
        void DeleteTariffRate(StandardRateMain standardRateMain);
        /// <summary>
        /// Add Standard Rate Main
        /// </summary>
        TariffRateContent AddTariffRate(StandardRateMain standardRateMain);
        /// <summary>
        /// Update Standard Rate Main
        /// </summary>
        TariffRateContent Update(StandardRateMain standardRateMain);
        /// <summary>
        /// Add Standard Rate Against Standard Rate Main
        /// </summary>
        void AddStandardRate(StandardRate standardRate);
        /// <summary>
        /// Find Standard Rate 
        /// </summary>
        IEnumerable<StandardRate> FindStandardRate(long standardRtMainId, long hireGroupDetailId);
        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<StandardRateMain> FindByTariffTypeCode(string tariffTypeCode);
    }
}
