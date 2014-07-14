using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Partner Rating Type Domain Model
    /// </summary>
    public class BpRatingType
    {
        #region Persisted Properties
        /// <summary>
        /// Business Partner Rating Type ID
        /// </summary>
        public int BpRatingTypeId { get; set; }
        /// <summary>
        /// Business Partner Rating Type Code
        /// </summary>
        [StringLength(100)]
        public string BpRatingTypeCode { get; set; }
        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        [StringLength(255)]
        public string BpRatingTypeName { get; set; }
        /// <summary>
        /// Business Partner Rating Type Description
        /// </summary>
        [StringLength(255)]
        public string BpRatingTypeDescription { get; set; }
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
