using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Chauffer Charge Main Repository Interface
    /// </summary>
    public interface IChaufferChargeMainRepository : IBaseRepository<ChaufferChargeMain, long>
    {
        /// <summary>
        /// Get All Chauffer Charge Main based on search crateria
        /// </summary>
        ChaufferChargeSearchResponse GetChaufferCharges(ChaufferChargeSearchRequest request);
    }
}
