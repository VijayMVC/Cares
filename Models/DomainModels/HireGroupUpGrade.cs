using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Up Grade Domain Model
    /// </summary>
    public class HireGroupUpGrade
    {
        #region Persisited Propertieset;
        /// <summary>
        /// Hire Group Up Grade Id
        /// </summary>
        public long HireGroupUpGradeId { get; set; }
        /// <summary>
        /// Hire Group Id
        /// </summary>
        [ForeignKey("HireGroup")]
        public long HireGroupId { get; set; }
        /// <summary>
        /// Allowed Hire Group Id
        /// </summary>
        [ForeignKey("AllowedHireGroup")]
        public long AllowedHireGroupId { get; set; }
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
        /// Is ReadOnly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

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
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Parent Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }
        public virtual HireGroup AllowedHireGroup { get; set; }
        #endregion
    }
}
