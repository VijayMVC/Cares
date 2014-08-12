using System;
using System.ComponentModel.DataAnnotations;
namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Partner Relationship Type Domain Model
    /// </summary>
    public class BusinessPartnerRelationshipType
    {
        #region Persisted Properties
        
        /// <summary>
        /// BusinessPartner Relationship Type ID
        /// </summary>
        public int BusinessPartnerRelationshipTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner Relationship Type Code
        /// </summary>
        [StringLength(100)]
        [Required]
        public string BusinessPartnerRelationshpTypeCode { get; set; }
 
        /// <summary>
        /// BusinessPartner Relationship Type Name
        /// </summary>
        [StringLength(255)]
        public string BusinessPartnerRelationshipTypeName { get; set; }
        
        /// <summary>
        /// BusinessPartner Relationship Type Description
        /// </summary>
        [StringLength(500)]
        public string BusinessPartnerRelationshipTypeDescription { get; set; }
        
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

        #endregion
    }
}
