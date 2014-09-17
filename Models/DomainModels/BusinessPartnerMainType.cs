using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Partner Main Type Domain Model
    /// </summary>
    public class BusinessPartnerMainType
    {
        #region Persisted Properties
        
        /// <summary>
        /// BusinessPartner MainType ID
        /// </summary>
        public short BusinessPartnerMainTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Code
        /// </summary>
        public string BusinessPartnerMainTypeCode { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Key
        /// </summary>
        public short BusinessPartnerMainTypeKey { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Name
        /// </summary>
        public string BusinessPartnerMainTypeName { get; set; }

        /// <summary>
        /// BusinessPartner MainType Description
        /// </summary>
        public string BusinessPartnerMainTypeDescription { get; set; }

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
        /// Business Partner Sub Type
        /// </summary>
        public ICollection<BusinessPartnerSubType> BusinessPartnerSubTypes { get; set; }

        #endregion
    }
}
