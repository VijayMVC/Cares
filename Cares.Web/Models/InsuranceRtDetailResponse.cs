using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Rate Detail Web Response
    /// </summary>
    public sealed class InsuranceRtDetailResponse
    {
        /// <summary>
        /// Insurance Rate List
        /// </summary>
        public IEnumerable<InsuranceRtDetailContent> InsuranceRateDetails { get; set; }
    }
}