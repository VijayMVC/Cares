using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Additional Charge Service
    /// </summary>
    public interface IAdditionalChargeService
    {
        /// <summary>
        /// Load Additional Charge Base data
        /// </summary>
        AdditionalChargeBaseResponse GetBaseData();

        /// <summary>
        /// Load Additional Charge Based on search criteria
        /// </summary>
        /// <returns></returns>
        AdditionalChargeSearchResponse LoadAll(AdditionalChargeSearchRequest request);
    }
}
