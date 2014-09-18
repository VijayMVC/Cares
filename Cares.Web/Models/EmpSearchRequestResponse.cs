using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Status Search Request Response web model
    /// </summary>
    public class EmpSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Employee Status List
        /// </summary>
        public IEnumerable<EmpStatus> EmployeeStatuses { get; set; }

        /// <summary>
        /// Total Count of Employee Status
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}