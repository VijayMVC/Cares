using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Data Response its detail that get by hire group id
    /// </summary>
    public sealed class HireGroupDataDetailResponse
    {
        /// <summary>
        /// Hire Group Details List
        /// </summary>
        public IEnumerable<HireGroupDetailContentForHireGroup> HireGroupDetails { get; set; }
        public IEnumerable<HireGroupUpgradeForHireGroup> HireGroupUpGrades { get; set; }
       
      
    }
}