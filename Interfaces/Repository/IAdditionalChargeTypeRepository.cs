using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Additional Charge Type Repository Interface
    /// </summary>
    public interface IAdditionalChargeTypeRepository : IBaseRepository<AdditionalChargeType, long>
    {

        /// <summary>
        /// Get All Additional Charges based on search crateria
        /// </summary>
        AdditionalChargeSearchResponse GetAdditionalCharges(AdditionalChargeSearchRequest request);

    }
}
