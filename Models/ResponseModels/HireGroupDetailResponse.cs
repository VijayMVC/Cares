using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Tariff Rate Detail Response
    /// </summary>
    public class HireGroupDetailResponse
    {
         /// <summary>
        /// Hire Group Details List
        /// </summary>
        public IEnumerable<HireGroupDetail> HireGroupDetails { get; set; } 
        /// <summary>
        /// Standard Rates List
        /// </summary>
        public IEnumerable<StandardRate> StandardRates { get; set; }
        /// <summary>
        /// Standard Rates Id
        /// </summary>
        public long StandardRateId { get; set; } 
       
    }
}
