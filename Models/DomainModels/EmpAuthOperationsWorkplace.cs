using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Authorized Operations Workplace Domain Model
    /// </summary>
    public class EmpAuthOperationsWorkplace
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Authorized Operations Workplace ID
        /// </summary>
        public long EmpAuthOperationsWorkplaceId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        public long OperationsWorkplaceId { get; set; }

        /// <summary>
        ///Is Default
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Is Operation Default
        /// </summary>
        public bool IsOperationDefault { get; set; }

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
        /// Operations Work Place
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkplace { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }
        #endregion
    }
}
