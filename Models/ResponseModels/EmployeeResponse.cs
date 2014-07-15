using System.Collections.Generic;
using Models.DomainModels;
namespace Models.ResponseModels
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
