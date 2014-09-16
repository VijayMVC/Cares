using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Partner SubType Domain Model
    /// </summary>
    public class BusinessPartnerSubType
    {
        #region Persisted Properties
        
        /// <summary>
        /// BusinessPartner SubType ID
        /// </summary>
        public int BusinessPartnerSubTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Code
        /// </summary>
        [StringLength(100)]
        [Required]
        public string BusinessPartnerSubTypeCode { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Key
        /// </summary>
        public int BusinessPartnerSubTypeKey { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Name
        /// </summary>
        [StringLength(255)]
        public string BusinessPartnerSubTypeName { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Description
        /// </summary>
        [StringLength(500)]
        public string BusinessPartnerSubTypeDescription { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType ID
        /// </summary>
        [ForeignKey("BusinessPartnerMainType")]
        public int BusinessPartnerMainTypeId { get; set; }
        
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
        /// Business Partner MainType Reference
        /// </summary>
        public virtual BusinessPartnerMainType BusinessPartnerMainType { get; set; }

        #endregion
    }
}
