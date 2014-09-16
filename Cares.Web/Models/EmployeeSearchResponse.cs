using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee List Web Response
    /// </summary>
    public class EmployeeSearchResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeSearchResponse()
        {
            Employees = new List<EmployeeListViewContent>();
        }

        /// <summary>
        /// Employees
        /// </summary>
        public IEnumerable<EmployeeListViewContent> Employees { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}