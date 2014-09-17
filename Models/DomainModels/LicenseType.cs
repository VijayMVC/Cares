using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// License Type Domain Model
    /// </summary>
    public class LicenseType
    {
        #region Persisted Properties

        /// <summary>
        /// License Type ID
        /// </summary>
        public long LicenseTypeId { get; set; }

        /// <summary>
        /// License Type Code
        /// </summary>
        public string LicenseTypeCode { get; set; }

        /// <summary>
        /// License Type Code
        /// </summary>
        public string LicenseTypeName { get; set; }

        /// <summary>
        /// License Type Description
        /// </summary>
        public string LicenseTypeDescription { get; set; }

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
        /// Employee Docs Infos
        /// </summary>
        public virtual ICollection<EmpDocsInfo> EmployeeDocsInfos { get; set; }

        #endregion
    }
}
