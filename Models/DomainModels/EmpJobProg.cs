using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Job Progress Domain MOdel
    /// </summary>
    public class EmpJobProg
    {
        #region Persisted Properties

        /// <summary>
        /// Employee Job Progress ID
        /// </summary>
        public long EmpJobProgId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        public long DesignationId { get; set; }

        /// <summary>
        ///Workplace ID
        /// </summary>
        public long WorkplaceId { get; set; }

        /// <summary>
        ///Joining Start Date
        /// </summary>
        public DateTime? DesigStDt { get; set; }

        /// <summary>
        /// Joining End Date
        /// </summary>
        public DateTime? DesigEndDt { get; set; }

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
        /// Designation
        /// </summary>
        public virtual Designation Designation { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// WorkPlace
        /// </summary>
        public virtual WorkPlace WorkPlace { get; set; }
        #endregion

    }
}
