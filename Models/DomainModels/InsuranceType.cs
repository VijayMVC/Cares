
using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Insurance Type Domain Model
    /// </summary>
    public class InsuranceType
    {
        #region Persisted Properties

        /// <summary>
        ///Insurance Type Id
        /// </summary>
        public short InsuranceTypeId { get; set; }

        /// <summary>
        /// Insurance Type Code
        /// </summary>
        [StringLength(100), Required]
        public string InsuranceTypeCode { get; set; }

        /// <summary>
        /// Insurance Type Name
        /// </summary>
        [StringLength(255)]
        public string InsuranceTypeName { get; set; }

        /// <summary>
        /// Insurance Type Description
        /// </summary>
        [StringLength(500)]
        public string InsuranceTypeDescription { get; set; }

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
