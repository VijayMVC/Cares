using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Hire Group Data Response its detail that get by hire group id
    /// </summary>
    public sealed class HireGroupDataDetailResponse
    {
        /// <summary>
        /// Hire Group Details List
        /// </summary>
        public IEnumerable<HireGroupDetail> HireGroupDetails { get; set; }
        
        /// <summary>
        /// Hire Group Up Grades
        /// </summary>
        public IEnumerable<HireGroupUpGrade> HireGroupUpGrades { get; set; }

        /// <summary>
        /// Hire Groups
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }
    }
}
