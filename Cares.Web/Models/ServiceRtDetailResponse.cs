using System.Collections.Generic;
namespace Cares.Web.Models
{/// <summary>
    /// Service Rate Detail Domain Response
    /// </summary>
    public sealed class ServiceRtDetailResponse
    {
        /// <summary>
        /// Service Rate Item List
        /// </summary>
        public IEnumerable<ServiceRtDetailContent> ServiceRateDetails { get; set; }
    }
}