using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Domain Model for Business Partner Company
    /// </summary>
    public class BusinessPartnerCompany
    {
        #region Persisted Properties
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [Required]
        [Key]
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Company Code
        /// </summary>
        [Required]
        [StringLength(100)]
        public string BusinessPartnerCompanyCode { get; set; }
        /// <summary>
        /// Business Partner Company Name
        /// </summary>
        [StringLength(255)]
        public string BusinessPartnerCompanyName { get; set; }
        /// <summary>
        /// Established Since
        /// </summary>
        public DateTime EstablishedSince { get; set; }
        /// <summary>
        /// Business Partner Company Swift Code
        /// </summary>
        [StringLength(100)]
        public string SwiftCode { get; set; }
        /// <summary>
        /// Business Partner Company Account Number
        /// </summary>
        [StringLength(100)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Business Segment ID
        /// </summary>
        public int BusinessSegmentId { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        ///// <summary>
        ///// Is Active
        ///// </summary>
        //public bool IsActive { get; set; }
        ///// <summary>
        ///// Is Deleted
        ///// </summary>
        //public bool IsDeleted { get; set; }
        ///// <summary>
        ///// Is Private
        ///// </summary>
        //public bool IsPrivate { get; set; }
        ///// <summary>
        ///// Is Readonly
        ///// </summary>
        //public bool IsReadOnly { get; set; }
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

        #region Reference Properties
        /// <summary>
        /// Business Segment
        /// </summary>
        public virtual BusinessSegment BusinessSegment { get; set; }

        #endregion
    }
}
