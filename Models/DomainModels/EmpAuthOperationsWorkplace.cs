using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Authorized Operations Workplace Domain Model
    /// </summary>
    public class EmpAuthOperationsWorkplace
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Authorized Operations Workplace ID
        /// </summary>
        public long EmpAuthOperationsWorkplaceId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        [ForeignKey("OperationsWorkPlace"), Required]
        public long OperationsWorkplaceId { get; set; }

        /// <summary>
        ///Is Default
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Is Operation Default
        /// </summary>
        public bool IsOperationDefault { get; set; }

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
        /// Operations Work Place
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlace { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }
        #endregion
    }
}
