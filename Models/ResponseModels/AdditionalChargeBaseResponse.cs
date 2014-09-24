using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Charge Base Response
    /// </summary>
    public class AdditionalChargeBaseResponse
    {
        /// <summary>
        /// Hire Group Details
        /// </summary>
        public IEnumerable<HireGroupDetail> HireGroupDetails { get; set; }
    }
}
