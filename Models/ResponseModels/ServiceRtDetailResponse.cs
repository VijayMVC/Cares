using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Rate Detail Domain Response
    /// </summary>
    public  sealed class ServiceRtDetailResponse
    {
        /// <summary>
        /// Service Rate List
        /// </summary>
        public List<ServiceRtDetailContent> ServiceRateDetails { get; set; }
    }
}
