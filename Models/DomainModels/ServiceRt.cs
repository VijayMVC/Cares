using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Rate Domain Models
    /// </summary>
    public class ServiceRt
    {
        /// <summary>
        /// Service Item Domain Models
        /// </summary>

        #region Persisted Properties

        /// <summary>
        ///Service Rate Id
        /// </summary>
        public long ServiceRtId { get; set; }

        /// <summary>
        /// Service Rate Main ID
        /// </summary>
        [ForeignKey("ServiceRtMain")]
        public long ServiceRtMainId { get; set; }

        /// <summary>
        /// Service Item Id
        /// </summary>
        [ForeignKey("ServiceItem")]
        public long ServiceItemId { get; set; }
        /// <summary>
        /// Child Service Rate Id
        /// </summary>
        [ForeignKey("ChildServiceRt")]
        public long? ChildServiceRtId { get; set; }

        /// <summary>
        /// Service Rate
        /// </summary>
        public float ServiceRate { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [Required]
        public DateTime StartDt { get; set; }

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
        /// Row Vesion
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Service Type
        /// </summary>
        public virtual ServiceItem ServiceItem { get; set; }

        /// <summary>
        /// Child Service Rt
        /// </summary>
        public virtual ServiceRt ChildServiceRt { get; set; }

        /// <summary>
        /// Service Rate Main
        /// </summary>
        public virtual ServiceRtMain ServiceRtMain { get; set; }

        #endregion
    }

}
