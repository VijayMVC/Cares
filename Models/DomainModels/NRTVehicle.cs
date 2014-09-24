using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Nrt Vehicle Model
    /// </summary>
    public class NrtVehicle
    {
        #region Persisted Properties
        
        /// <summary>
        /// Nrt Vehicle ID
        /// </summary>
        public long NrtVehicleId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// NRT Main ID
        /// </summary>
        public long NrtMainId { get; set; }
        
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
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// NRT Vehicle Movements
        /// </summary>
        public virtual ICollection<NrtVehicleMovement> NrtVehicleMovements { get; set; }

        /// <summary>
        /// NRT Charges
        /// </summary>
        public virtual ICollection<NrtCharge> NrtCharges { get; set; }

        /// <summary>
        /// NRT Drivers
        /// </summary>
        public virtual ICollection<NrtDriver> NrtDrivers { get; set; }

        /// <summary>
        /// Nrt Main
        /// </summary>
        public virtual NrtMain NrtMain { get; set; }

        #endregion
    }
}
