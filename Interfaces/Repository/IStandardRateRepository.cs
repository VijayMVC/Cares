using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Standard Rate Interface
    /// </summary>
    public interface IStandardRateRepository : IBaseRepository<StandardRate, long>
    {
        /// <summary>
        /// Get Standard Rate For Tariff Rate
        /// </summary>
        IEnumerable<StandardRate> GetStandardRateForTariffRate(long standardRtMainId);
        
        /// <summary>
        /// Find By Hire Group Id and standard Rate Main Id
        /// </summary>
        IEnumerable<StandardRate> FindByHireGroupId(long standardRtMainId, long hireGroupDetailId);

        /// <summary>
        /// Get Insurance Rate For RA Billing 
        /// </summary>
        IEnumerable<StandardRate> GetForRaBilling(string tariffTypeCode, long hireGroupDetailId, DateTime raRecCreatedDate);

     
    }
}
