using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Parent Hiregroup Response for Loading Dropdown
    /// </summary>
    public class ParentHireGroupResponse
    {
        /// <summary>
        /// Parent Hiregroups
        /// </summary>
        public IEnumerable<ParentHireGroup> HireGroups { get; set; }
    }
}