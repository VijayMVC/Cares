using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Department Type Domain Model
    /// </summary>
    public class DepartmentType
    {
        #region Persisted Properties

        /// <summary>
        /// Department Type ID
        /// </summary>
        public short DepartmentTypeId { get; set; }

        /// <summary>
        /// DepartmentType Code
        /// </summary>
        [StringLength(100), Required]
        public string DepartmentTypeCode { get; set; }

        /// <summary>
        /// DepartmentType Name
        /// </summary>
        [StringLength(255)]
        public string DepartmentTypeName { get; set; }

        /// <summary>
        /// DepartmentType Description
        /// </summary>
        [StringLength(500)]
        public string DepartmentTypeDescription { get; set; }

        /// <summary>
        /// Department Type Cat
        /// </summary>
        public short? DepartmentTypeCat { get; set; }

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

        #endregion

        #region Reference Properties

        /// <summary>
        /// Departments associated to this Type
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }

        #endregion
    }
}
