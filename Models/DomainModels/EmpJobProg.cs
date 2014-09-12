using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Job Progress Domain MOdel
    /// </summary>
    public class EmpJobProg
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Job Progress ID
        /// </summary>
        public long EmpJobProgId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
        [ForeignKey("")]
        public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        [ForeignKey(""), Required]
        public long DesignationId { get; set; }

        /// <summary>
        ///Workplace ID
        /// </summary>
        [ForeignKey(""), Required]
        public long WorkplaceId { get; set; }

        /// <summary>
        ///Joining Start Date
        /// </summary>
        public DateTime? DesigStDt { get; set; }

        /// <summary>
        /// Joining End Date
        /// </summary>
        public DateTime? DesigEndDt { get; set; }

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
