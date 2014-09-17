using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Designation Domain Model
    /// </summary>
    public class Designation
    {
        #region Persisted Properties

        /// <summary>
        /// Designation ID
        /// </summary>
        public long DesignationId { get; set; }

        /// <summary>
        /// Designation Code
        /// </summary>
        public string DesignationCode { get; set; }

        /// <summary>
        /// Designation Code
        /// </summary>
        public string DesignationName { get; set; }

        /// <summary>
        /// Designation Description
        /// </summary>
        public string DesignationDescription { get; set; }

        /// <summary>
        /// Designation Key
        /// </summary>
        public long? DesignationKey { get; set; }

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

        /// <summary>
        /// Employee Job Progs
        /// </summary>
        public virtual ICollection<EmpJobProg> EmployeeJobProgs { get; set; }

        #endregion

    }
}
