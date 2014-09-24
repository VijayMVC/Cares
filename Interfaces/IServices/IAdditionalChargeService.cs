using Cares.Models.DomainModels;
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

        /// <summary>
        /// Save Additional Charge
        /// </summary>
        /// <param name="additionalChargeType"></param>
        /// <returns></returns>
        AdditionalChargeType SaveAdditionalCharge(AdditionalChargeType additionalChargeType);

        /// <summary>
        /// Delete Additional Charge
        /// </summary>
        /// <param name="additionalChargeType"></param>
        /// <returns></returns>
        void DeleteAdditionalCharge(AdditionalChargeType additionalChargeType);

        /// <summary>
        /// Find Additional Charge By Id
        /// </summary>
        /// <param name="additionalChargeTypeId"></param>
        /// <returns></returns>
        AdditionalChargeType FindById(long additionalChargeTypeId);
    }
}
