using System;
using System.Collections.Generic;
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
        public short BusinessSegmentId { get; set; }
        
        /// <summary>
        /// Business Segment Code
        /// </summary>
        [StringLength(100), Required]
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
        /// Business Partner Company Associated to this
        /// </summary>
        public virtual ICollection<BusinessPartnerCompany> BusinessPartnerCompanies { get; set; }
        
        #endregion
    }
}
