using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
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
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
