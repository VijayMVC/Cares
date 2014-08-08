using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100)]
        public string OrgGroupCode { get; set; }

        /// <summary>
        /// Organization Group Name
        /// </summary>
        [StringLength(255), Required]
        public string OrgGroupName { get; set; }

        /// <summary>
        /// Organization Group Description
        /// </summary>
        [StringLength(500)]
        public string OrgGroupDescription { get; set; }

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
        /// Companies Assocaited to this OrgGroup
        /// </summary>
        public virtual ICollection<Company> Companies { get; set; }

        #endregion
    }
}
