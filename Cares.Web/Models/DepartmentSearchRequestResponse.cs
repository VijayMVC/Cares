using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Web Model
    /// </summary>
    public sealed class DepartmentSearchRequestResponse
    {
        /// <summary>
        /// FleetPools
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// FleetPool Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}