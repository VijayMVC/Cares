using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Insurance Rate Service Interface
    /// </summary>
    public interface IInsuranceRateService
    {
        /// <summary>
        /// Get Base Data
        /// </summary>
        InsuranceRateBaseResponse GetBaseData();
        /// <summary>
        /// Load Insurance Rates
        /// </summary>
        InsuranceRateSearchResponse LoadInsuranceRates(InsuranceRateSearchRequest request);
    }
}
