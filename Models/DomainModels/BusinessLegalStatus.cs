using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Legal Status Domain Model
    /// </summary>
    public class BusinessLegalStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Business Legal Status ID
        /// </summary>
        public short BusinessLegalStatusId { get; set; }
        
        /// <summary>
        /// Business Legal Status Code
        /// </summary>
        public string BusinessLegalStatusCode { get; set; }
        
        /// <summary>
        /// Business Legal Status Name
        /// </summary>
        public string BusinessLegalStatusName { get; set; }

        /// <summary>
        /// Business Legal Status Description
        /// </summary>
        public string BusinessLegalStatusDescription { get; set; }

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

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partners Associated to this
        /// </summary>
        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; }
        
        #endregion
    }
}
