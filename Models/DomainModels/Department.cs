using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Department Domain Model
    /// </summary>
    public class Department
    {
        #region Persisted Properties
        
        /// <summary>
        /// Department ID
        /// </summary>
        public long DepartmentId { get; set; }
        
        /// <summary>
        /// Department Code
        /// </summary>
        [StringLength(100), Required]
        public string DepartmentCode { get; set; }
        
        /// <summary>
        /// Department Code
        /// </summary>
        [StringLength(255)]
        public string DepartmentName { get; set; }
        
        /// <summary>
        /// Department Description
        /// </summary>
        [StringLength(500)]
        public string DepartmentDescription { get; set; }
        
        /// <summary>
        /// Department Type
        /// </summary>
        [Required]
        [StringLength(100)]
        public string DepartmentType { get; set; }
        
        /// <summary>
        /// Company ID
        /// </summary>
        [ForeignKey("Company")]
        public long CompanyId { get; set; }

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
        /// Company
        /// </summary>
        public virtual Company Company{ get; set; }
        
        /// <summary>
        /// Operations
        /// </summary>
        public virtual ICollection<Operation> Operations { get; set; }

        /// <summary>
        /// Employees in this department
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; } 

        #endregion
    }
}
