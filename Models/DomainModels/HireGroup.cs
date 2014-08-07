using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Domain Model
    /// </summary>
    public class HireGroup
    {
        #region Persisted Properties
        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Parent Hire Group ID
        /// </summary>
        [Key]
        public long ParentHireGroupId { get; set; }
        /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        ///Hire Group Name
        /// </summary>
        [StringLength(255)]
        public string HireGroupName { get; set; }
        /// <summary>
        /// Hire Group Code
        /// </summary>
        [StringLength(100)]
        public string HireGroupCode { get; set; }
        /// <summary>
        /// Hire Group Description
        /// </summary>
        [StringLength(500)]
        public string HireGroupDescription { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Parent
        /// </summary>
        public bool IsParent { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion
    }
}
