using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Detail Web Response
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