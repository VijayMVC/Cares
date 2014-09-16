using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Insurance Rate Repository Interface
    /// </summary>
    public interface IInsuranceRtRepository : IBaseRepository<InsuranceRt, long>
    {
        /// <summary>
        /// Get Insurance Rate By Insurance Rate Main ID 
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        IEnumerable<InsuranceRt> GetInsuranceRtByInsuranceRtMainId(long insuranceRtMainId);
    }
}
