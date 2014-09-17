using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Maintenance Type Domain Model
    /// </summary>
    public class MaintenanceType
    {
        #region Persisted Properties

        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeId { get; set; }

        /// <summary>
        /// Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Code
        /// </summary>
        public string MaintenanceTypeCode { get; set; }

        /// <summary>
        /// Maintenance Type Name
        /// </summary>
        public string MaintenanceTypeName { get; set; }

        /// <summary>
        ///Maintenance Type Description
        /// </summary>
        public string MaintenanceTypeDescription { get; set; }

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
        /// Maintenance Type Group
        /// </summary>
        public virtual MaintenanceTypeGroup MaintenanceTypeGroup { get; set; }

        /// <summary>
        /// Vehicle Maintenance Type Frequencies
        /// </summary>
        public virtual ICollection<VehicleMaintenanceTypeFrequency> VehicleMaintenanceTypeFrequencies { get; set; } 

        #endregion
    }
}
