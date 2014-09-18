using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

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
        [Key, ForeignKey("Employee")]
        public long EmployeeId { get; set; }
        

        /// <summary>
        /// Supervisor Id
        /// </summary>        
        [ForeignKey("Supervisor")]
        public long? SupervisorId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        [ForeignKey("Designation"), Required]
        public long DesignationId { get; set; }


        /// <summary>
        /// Designation Grade Id
        /// </summary>
        [ForeignKey("DesigGrade"), Required]
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Job Type ID
        /// </summary>
        [ForeignKey("JobType"), Required]
        public long JobTypeId { get; set; }

        /// <summary>
        /// Department ID
        /// </summary>
        [ForeignKey("Department"), Required]
        public long DepartmentId { get; set; }

        /// <summary>
        ///Workplace ID
        /// </summary>
        [ForeignKey("WorkPlace"), Required]
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
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
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
        public virtual DesignGrade DesigGrade { get; set; }

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
