using System;
using System.Collections.Generic;

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
        public short BusinessPartnerRelationshipTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner Relationship Type Code
        /// </summary>
        public string BusinessPartnerRelationshpTypeCode { get; set; }
 
        /// <summary>
        /// BusinessPartner Relationship Type Name
        /// </summary>
        public string BusinessPartnerRelationshipTypeName { get; set; }
        
        /// <summary>
        /// BusinessPartner Relationship Type Description
        /// </summary>
        public string BusinessPartnerRelationshipTypeDescription { get; set; }
        
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
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partner Relationships
        /// </summary>
        public virtual ICollection<BusinessPartnerRelationship> BusinessPartnerRelationships { get; set; }

        #endregion
    }
}
