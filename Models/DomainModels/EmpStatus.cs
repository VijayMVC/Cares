using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Status Domain Model
    /// </summary>
    public class EmpStatus
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Status ID
        /// </summary>
        public long EmpStatusId { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        [StringLength(100), Required]
        public string EmpStatusCode { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        [StringLength(255)]
        public string EmpStatusName { get; set; }

        /// <summary>
        /// Employee Satus Description
        /// </summary>
        [StringLength(500)]
        public string EmpStatusDescription { get; set; }

        /// <summary>
        /// Employee Satus Flag
        /// </summary>
        [Required]
        public bool EmpStatusFlag { get; set; }

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
    }
}
