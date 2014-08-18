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
    }
}
