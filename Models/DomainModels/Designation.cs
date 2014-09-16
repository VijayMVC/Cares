using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Designation Domain Model
    /// </summary>
    public class Designation
    {
        #region Persisted Properties

        /// <summary>
        /// Designation ID
        /// </summary>
        public long DesignationId { get; set; }

        /// <summary>
        /// Designation Code
        /// </summary>
        [StringLength(100), Required]
        public string DesignationCode { get; set; }

        /// <summary>
        /// Designation Code
        /// </summary>
        [StringLength(255)]
        public string DesignationName { get; set; }

        /// <summary>
        /// Designation Description
        /// </summary>
        [StringLength(500)]
        public string DesignationDescription { get; set; }

        /// <summary>
        /// Designation Key
        /// </summary>
        public long? DesignationKey { get; set; }

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
