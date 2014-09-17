using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Job Type Domain Model
    /// </summary>
    public class JobType
    {
        #region Persisted Properties

        /// <summary>
        /// Job Type ID
        /// </summary>
        public long JobTypeId { get; set; }

        /// <summary>
        /// Job Type Code
        /// </summary>
        public string JobTypeCode { get; set; }

        /// <summary>
        /// Job Type Code
        /// </summary>
        public string JobTypeName { get; set; }

        /// <summary>
        /// Job Type Description
        /// </summary>
        public string JobTypeDescription { get; set; }

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
        /// Employee Job Infos
        /// </summary>
        public virtual ICollection<EmpJobInfo> EmployeeJobInfos { get; set; } 

        #endregion
    }
}
