using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Insurance Rate
    /// </summary>
    public class InsuranceRt
    {
        #region Persisted Properties

        /// <summary>
        /// Insurance Rate ID
        /// </summary>
        public long InsuranceRtId { get; set; }
        /// <summary>
        ///Insurance Rate MainId
        /// </summary>
        [ForeignKey("InsuranceRtMain")]
        public long InsuranceRtMainId { get; set; }
        /// <summary>
        /// Child Insurance Rate ID
        /// </summary>
        [ForeignKey("ChildInsuranceRt")]
        public long? ChildInsuranceRtId { get; set; }
        /// <summary>
        /// Insurance Type ID
        /// </summary>
        [ForeignKey("InsuranceType")]
        public short InsuranceTypeId { get; set; }
        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        [ForeignKey("HireGroupDetail")]
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Insurance Rate
        /// </summary>
        public float InsuranceRate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [Required]
        public DateTime StartDt { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        [Required]
        public long RevisionNumber { get; set; }

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
        /// Child Insurance Rate
        /// </summary>
        public virtual InsuranceRt ChildInsuranceRt { get; set; }
        /// <summary>
        /// Insurance Rate Main
        /// </summary>
        public virtual InsuranceRtMain InsuranceRtMain { get; set; }

        /// <summary>
        ///Insurance Type
        /// </summary>
        public virtual InsuranceType InsuranceType { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        #endregion
    }
}
