using System.Collections.Generic;
using Models.DomainModels;


namespace Interfaces.Repository
{
    /// <summary>
    /// Hire Group Detail Interface
    /// </summary>
    public interface IHireGroupDetailRepository: IBaseRepository<HireGroupDetail, long>
    {
        /// <summary>
        /// Get Hire Group Details For Tarif fRate
        /// </summary>
        /// <returns></returns>
        IEnumerable<HireGroupDetail> GetHireGroupDetailsForTariffRate();
    }
}
