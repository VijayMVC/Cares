using System.Collections.Generic;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Standard Rate Main Interface
    /// </summary>
    public interface IStandardRateMainRepository : IBaseRepository<StandardRateMain, long>
    {
        /// <summary>
        ///  Get all Tarrif Rates, based on filters
        /// </summary>
        /// <param name="tariffRateRequest"></param>
        /// <returns></returns>
        TariffRateResponse GetTariffRates(TariffRateRequest tariffRateRequest);
        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<StandardRateMain> FindByTariffTypeCode(string tariffTypeCode);
    }
}
