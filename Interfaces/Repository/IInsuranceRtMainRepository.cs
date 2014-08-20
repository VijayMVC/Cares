using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Insurance Rate Main Repository Interface
    /// </summary>
    public interface IInsuranceRtMainRepository : IBaseRepository<InsuranceRtMain, long>
    {
        /// <summary>
        /// Get Insurance Rates based on search criteria
        /// </summary>
        /// <param name="insuranceRateSearchRequest"></param>
        /// <returns></returns>
        InsuranceRateSearchResponse GetInsuranceRates(InsuranceRateSearchRequest insuranceRateSearchRequest);
        /// <summary>
        /// Get Insurance Rate Main By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<InsuranceRtMain> FindByTariffTypeCode(string tariffTypeCode);

        
    }
}
