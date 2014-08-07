using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    /// <summary>
    /// Standard Rate Service
    /// </summary>
    public class StandardRateService : IStandardRateService
    {
        private readonly IStandardRateRepository iRepository;
        #region Constructor
        public StandardRateService(IStandardRateRepository xRepository)
        {
            iRepository = xRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        public IEnumerable<StandardRate> FindStandardRate(long standardRtMainId, long hireGroupDetailId)
        {
            return iRepository.FindByHireGroupId(standardRtMainId, hireGroupDetailId);
        }
        #endregion
    }
}
