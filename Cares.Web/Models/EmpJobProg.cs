using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee  Job Progress Web MOdel
    /// </summary>
    public sealed class EmpJobProg
    {
        /// <summary>
        /// Employee Job Progress ID
        /// </summary>
        public long EmpJobProgId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
         public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
          public long DesignationId { get; set; }

        /// <summary>
        ///Workplace ID
        /// </summary>
         public long WorkplaceId { get; set; }

        /// <summary>
        ///Joining Start Date
        /// </summary>
        public DateTime? DesigStDt { get; set; }

        /// <summary>
        /// Joining End Date
        /// </summary>
        public DateTime? DesigEndDt { get; set; }
    }
}