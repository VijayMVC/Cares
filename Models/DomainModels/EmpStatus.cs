using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Status Domain Model
    /// </summary>
    public class EmpStatus
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Status ID
        /// </summary>
        public long EmpStatusId { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        public string EmpStatusCode { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        public string EmpStatusName { get; set; }

        /// <summary>
        /// Employee Satus Description
        /// </summary>
        public string EmpStatusDescription { get; set; }

        /// <summary>
        /// Employee Satus Flag
        /// </summary>
        public bool EmpStatusFlag { get; set; }

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
        /// Employees
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; } 

        #endregion
    }
}
