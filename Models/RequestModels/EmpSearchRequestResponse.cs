using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Employee Status Search Request Response domain model
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
