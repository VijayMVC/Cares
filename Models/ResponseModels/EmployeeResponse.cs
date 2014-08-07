using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Employee Response
    /// </summary>
    public sealed class EmployeeResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeResponse()
        {
            Employees = new List<Employee>();
        }

        /// <summary>
        /// Employees
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
