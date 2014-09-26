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

        /// <summary>
        /// Validate Chauffer Charge Main Already exist Against Tariff type Code 
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        bool LoadChaufferChargeMainExist(string tariffTypeCode);

    }
}
