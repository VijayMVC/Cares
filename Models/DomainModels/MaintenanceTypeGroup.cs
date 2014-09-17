using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Maintenance Type Group Domain Model
    /// </summary>
    public class MaintenanceTypeGroup
    {
        #region Persisted Properties

        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Group Code
        /// </summary>
        public string MaintenanceTypeGroupCode { get; set; }

        /// <summary>
        /// Maintenance Type Group Name
        /// </summary>
        public string MaintenanceTypeGroupName { get; set; }

        /// <summary>
        ///Maintenance Type Group Description
        /// </summary>
        public string MaintenanceTypeGroupDescription { get; set; }

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
        /// Row Vesion
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Maintenance Types
        /// </summary>
        public virtual ICollection<MaintenanceType> MaintenanceTypes { get; set; } 

        #endregion
    }
}
