using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// DocumentGroup Domain Model
    /// </summary>
    public class DocumentGroup
    {
        #region Persisted Properties
        
        /// <summary>
        /// DocumentGroup ID
        /// </summary>
        public int DocumentGroupId { get; set; }

        /// <summary>
        /// DocumentGroup Code
        /// </summary>
        public string DocumentGroupCode { get; set; }

        /// <summary>
        /// DocumentGroup Name
        /// </summary>
        public string DocumentGroupName { get; set; }

        /// <summary>
        /// DocumentGroup Description
        /// </summary>
        public string DocumentGroupDescription { get; set; }
        
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
        /// Documents
        /// </summary>
        public virtual ICollection<Document> Documents { get; set; }

        #endregion
    }
}
