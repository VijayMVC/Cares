using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Up Grade Domain Model
    /// </summary>
    public class HireGroupUpGrade
    {
        #region Persisited Properties
        /// <summary>
        /// Hire Group Up Grade Id
        /// </summary>
        public long HireGroupUpGradeId { get; set; }
        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// Allowed Hire Group Id
        /// </summary>
        public long AllowedHireGroupId { get; set; }
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
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Parent Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }

        /// <summary>
        /// Allowed Hire Group
        /// </summary>
        public virtual HireGroup AllowedHireGroup { get; set; }
        #endregion
    }
}
