using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Standard Rate Interface
    /// </summary>
    public interface IStandardRateRepository : IBaseRepository<StandardRate, long>
    {
        /// <summary>
        /// Get Standard Rate For Tariff Rate
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <returns></returns>
        IEnumerable<StandardRate> GetStandardRateForTariffRate(long standardRtMainId);
        /// <summary>
        /// Find By Hire Group Id and standard Rate Main Id
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        IEnumerable<StandardRate> FindByHireGroupId(long standardRtMainId, long hireGroupDetailId);
    }
}
