using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Organization Group Domain Model
    /// </summary>
    public class OrgGroup
    {
        #region Persisted Properties

        /// <summary>
        /// Organization Group ID
        /// </summary>
        public long OrgGroupId { get; set; }

        /// <summary>
        /// Organization Group Code
        /// </summary>
        public string OrgGroupCode { get; set; }

        /// <summary>
        /// Organization Group Name
        /// </summary>
        public string OrgGroupName { get; set; }

        /// <summary>
        /// Organization Group Description
        /// </summary>
        public string OrgGroupDescription { get; set; }

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
        /// Companies Assocaited to this OrgGroup
        /// </summary>
        public virtual ICollection<Company> Companies { get; set; }

        #endregion
    }
}
