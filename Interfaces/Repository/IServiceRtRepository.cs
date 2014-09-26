using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Service Rate Repository Interface
    /// </summary>
    public interface IServiceRtRepository : IBaseRepository<ServiceRt, long>
    {
        /// <summary>
        /// Get Service Rate By Service Rate Main Id
        /// </summary>
        IEnumerable<ServiceRt> GetServiceRtByServiceRtMainId(long serviceRtMainId);

        /// <summary>
        /// Get Service Rate For RA Billing 
        /// </summary>
        IEnumerable<ServiceRt> GetForRaBilling(string tariffTypeCode, long serviceItemId, DateTime raRecCreatedDate);
        
        /// <summary>
        /// Association check with service item 
        /// </summary>
        bool IsServiceRtAssociatedWithServiceItemValidation(long serviceItemId);
    }
}
