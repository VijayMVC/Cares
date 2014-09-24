using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Status Domain Model
    /// </summary>
    public class VehicleStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Code
        /// </summary>
        public string VehicleStatusCode { get; set; }

        /// <summary>
        /// Vehicle Status Name
        /// </summary>
        public string VehicleStatusName { get; set; }

        /// <summary>
        /// Vehicle Status Description
        /// </summary>
        public string VehicleStatusDescription { get; set; }

        /// <summary>
        /// Vehicle Status Key
        /// </summary>
        public short? VehicleStatusKey { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Availability Check
        /// </summary>
        public bool AvailabilityCheck { get; set; }

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
        /// Vehicle Sub Statuses
        /// </summary>
        public virtual ICollection<VehicleSubStatus> VehicleSubStatuses { get; set; }

        /// <summary>
        /// Vehicles having this Vehicle Status
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// NRT Vehicle Movements
        /// </summary>
        public virtual ICollection<NrtVehicleMovement> NrtVehicleMovements { get; set; }

        /// <summary>
        /// NRT Types
        /// </summary>
        public virtual ICollection<NrtType> NrtTypes { get; set; }

        /// <summary>
        /// Vehicle Movements
        /// </summary>
        public virtual ICollection<VehicleMovement> VehicleMovements { get; set; }

        #endregion
    }
}
