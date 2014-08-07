using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;


namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Standard Rate Main Interface
    /// </summary>
    public interface IStandardRateMainRepository : IBaseRepository<StandardRateMain, long>
    {
        /// <summary>
        ///  Get all Tarrif Rates, based on filters
        /// </summary>
        TariffRateResponse GetTariffRates(TariffRateRequest tariffRateRequest);
        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<StandardRateMain> FindByTariffTypeCode(string tariffTypeCode);
    }
}
