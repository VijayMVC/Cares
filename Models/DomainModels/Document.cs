using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Document Domain Model
    /// </summary>
    public class Document
    {
        #region Persisted Properties
        
        /// <summary>
        /// Document ID
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Document Code
        /// </summary>
        public string DocumentCode { get; set; }

        /// <summary>
        /// Document Name
        /// </summary>
        public string DocumentName { get; set; }

        /// <summary>
        /// Document Description
        /// </summary>
        public string DocumentDescription { get; set; }

        /// <summary>
        /// Document Group ID
        /// </summary>
        public int DocumentGroupId { get; set; }
        
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
        /// Document Group
        /// </summary>
        public virtual DocumentGroup DocumentGroup { get; set; }

        #endregion
    }
}
