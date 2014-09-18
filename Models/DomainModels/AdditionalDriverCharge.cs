using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Additional Driver Charge Domain Model
    /// </summary>
    public class AdditionalDriverCharge
    {
        #region Persisted Properties
        /// <summary>
        /// Additional Driver Charge ID
        /// </summary>
        [Key]
        public long AdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Child Additional Driver Charge ID
        /// </summary>
        [ForeignKey("ChildAdditionalDriverCharge")]
        public long? ChildAdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        [StringLength(100),Required]
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Additional Driver Charge Rate
        /// </summary>
        public float AdditionalDriverChargeRate { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

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
        /// Child Additional Driver Charge
        /// </summary>
        public virtual AdditionalDriverCharge ChildAdditionalDriverCharge { get; set; }
        #endregion
    }
}
