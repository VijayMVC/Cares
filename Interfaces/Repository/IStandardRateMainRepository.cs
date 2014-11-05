using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
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
        ///  Get all tariff Rates, based on filters
        /// </summary>
        TariffRateResponse GetTariffRates(TariffRateSearchRequest tariffRateRequest);

        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<StandardRateMain> FindByTariffTypeCode(string tariffTypeCode);

        /// <summary>
        /// Get By Standard Rate Main Code
        /// </summary>
        /// <returns></returns>
        IEnumerable<StandardRateMain> GetByStandardRateMainCode(string standardRateMainCode);


      
    }
}
