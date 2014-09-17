using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Job Info Web Model
    /// </summary>
    public sealed class EmpJobInfo
    {

        /// <summary>
        /// Job Info Id
        /// </summary>
        public long JobInfoId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Supervisor Id
        /// </summary>
        public long? SupervisorId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        public long DesignationId { get; set; }


        /// <summary>
        /// Designation Grade Id
        /// </summary>
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Job Type ID
        /// </summary>
        public long JobTypeId { get; set; }

        /// <summary>
        /// Department ID
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        ///Workplace ID
        /// </summary>
        public long WorkplaceId { get; set; }

        /// <summary>
        ///Joining Date
        /// </summary>
        public DateTime JoiningDt { get; set; }

        /// <summary>
        ///Salary
        /// </summary>
        public decimal? Salary { get; set; }
    }
}