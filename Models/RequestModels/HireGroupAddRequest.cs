using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Hire Group Add Request
    /// </summary>
    public sealed class HireGroupAddRequest
    {
        /// <summary>
        /// Hire Group
        /// </summary>
        public HireGroup HireGroup { get; set; }
        /// <summary>
        /// Hire Group List
        /// </summary>
        public IEnumerable<HireGroupDetail> HireGroupDetails { get; set; }
        /// <summary>
        /// Hire Group Up Garde List
        /// </summary>
        public IEnumerable<HireGroupUpGrade> HireGroupUpGrades { get; set; }
    }
}
