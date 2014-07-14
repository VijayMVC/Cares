using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Segment Domain Model
    /// </summary>
    public class BusinessSegment
    {
        #region Persisted Properties
        /// <summary>
        /// Business Segment ID
        /// </summary>
        public int BusinessSegmentId { get; set; }
        /// <summary>
        /// Business Segment Code
        /// </summary>
        [StringLength(100)]
        public string BusinessSegmentCode { get; set; }
        /// <summary>
        /// Business Segment Name
        /// </summary>
        [StringLength(255)]
        public string BusinessSegmentName { get; set; }
        /// <summary>
        /// Business Segment Description
        /// </summary>
        [StringLength(500)]
        public string BusinessSegmentDescription { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion
    }
}
