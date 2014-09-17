using System;
using System.Collections.Generic;

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
        public short BusinessPartnerSubTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Code
        /// </summary>
        public string BusinessPartnerSubTypeCode { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Key
        /// </summary>
        public short? BusinessPartnerSubTypeKey { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Name
        /// </summary>
        public string BusinessPartnerSubTypeName { get; set; }
        
        /// <summary>
        /// BusinessPartner SubType Description
        /// </summary>
        public string BusinessPartnerSubTypeDescription { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType ID
        /// </summary>
        public short BusinessPartnerMainTypeId { get; set; }
        
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
        /// Business Partner MainType Reference
        /// </summary>
        public virtual BusinessPartnerMainType BusinessPartnerMainType { get; set; }


        /// <summary>
        /// Business Partner MainType Reference
        /// </summary>
        public virtual ICollection<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }

        #endregion
    }
}
