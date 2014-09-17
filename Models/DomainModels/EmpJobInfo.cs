using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Job Info
    /// </summary>
    public class EmpJobInfo
    {
        #region Persisted Properties

        /// <summary>
        /// Job Info Id
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
        public long WorkPlaceId { get; set; }

        /// <summary>
        ///Joining Date
        /// </summary>
        public DateTime JoiningDt { get; set; }

        /// <summary>
        ///Salary
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Department
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Designation Grade
        /// </summary>
        public virtual DesigGrade DesigGrade { get; set; }

        /// <summary>
        /// Designation
        /// </summary>
        public virtual Designation Designation { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        ///  Supervisor
        /// </summary>
        public virtual Employee Supervisor { get; set; }

        /// <summary>
        /// Job Type
        /// </summary>
        public virtual JobType JobType { get; set; }

        /// <summary>
        /// WorkPlace
        /// </summary>
        public virtual WorkPlace WorkPlace { get; set; }
        #endregion
    }
}
