using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Service Rate Main Repository
    /// </summary>
    public interface IServiceRtMainRepository : IBaseRepository<ServiceRtMain, long>
    {
        /// <summary>
        /// Get Service Main Rates
        /// </summary>
        /// <param name="serviceRateSearchRequest"></param>
        /// <returns></returns>
        ServiceRateSearchResponse GetServiceRates(ServiceRateSearchRequest serviceRateSearchRequest);

        /// <summary>
        /// Get  Insurance Rate Main By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<ServiceRtMain> FindByTariffTypeCode(string tariffTypeCode);

        /// <summary>
        /// Service Rate Main Code validation check
        /// </summary>
        bool IsServiceRtMainCodeExists(string serviceRtMainCode, long serviceRtMainId);

    }
}
