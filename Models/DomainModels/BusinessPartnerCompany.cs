using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [ForeignKey("BusinessPartner")]
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
        public DateTime? EstablishedSince { get; set; }

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
        [ForeignKey("BusinessSegment")]
        public short? BusinessSegmentId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
     
        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Segment
        /// </summary>
        public virtual BusinessSegment BusinessSegment { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
