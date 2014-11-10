using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Allocation Status Domain Model
    /// </summary>
    public class AllocationStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Allocation Status ID
        /// </summary>
        public short AllocationStatusId { get; set; }

        /// <summary>
        /// Allocation Status Code
        /// </summary>
        public string AllocationStatusCode { get; set; }

        /// <summary>
        /// Allocation Status Name
        /// </summary>
        public string AllocationStatusName { get; set; }

        /// <summary>
        /// Allocation Status Description
        /// </summary>
        public string AllocationStatusDescription { get; set; }

        /// <summary>
        /// Allocation Status Key
        /// </summary>
        public short? AllocationStatusKey { get; set; }
        
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
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Ra HireGroups
        /// </summary>
        public virtual ICollection<RaHireGroup> RaHireGroups { get; set; }

        #endregion
    }
}
