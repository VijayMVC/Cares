using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Insurance Rate Detail Domain Response
    /// </summary>
    public sealed class InsuranceRtDetailResponse
    {
        /// <summary>
        /// Insurance Rate List
        /// </summary>
        public List<InsuranceRtDetailContent> InsuranceRateDetails { get; set; }

    }
}
