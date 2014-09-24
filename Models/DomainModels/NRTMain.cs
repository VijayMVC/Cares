using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Nrt Main Model
    /// </summary>
    public class NrtMain
    {
        #region Persisted Properties
        
        /// <summary>
        /// Nrt Main ID
        /// </summary>
        public long NrtMainId { get; set; }

        /// <summary>
        /// Nrt Type
        /// </summary>
        public long NrtTypeId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public long OpenLocationId { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public long CloseLocationId { get; set; }

        /// <summary>
        /// Nrt Status Id
        /// </summary>
        public short NrtStatusId { get; set; }
        
        /// <summary>
        /// Nrt Main Description
        /// </summary>
        public string NrtMainDescription { get; set; }
        
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

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
        /// Nrt Status
        /// </summary>
        public virtual RaStatus NrtStatus { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public virtual OperationsWorkPlace OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public virtual OperationsWorkPlace CloseLocation { get; set; }

        /// <summary>
        /// Nrt Type
        /// </summary>
        public virtual NrtType NrtType { get; set; }

        /// <summary>
        /// Chauffer Reservations
        /// </summary>
        public virtual ICollection<ChaufferReservation> ChaufferReservations { get; set; }

        /// <summary>
        /// Vehicle Reservations
        /// </summary>
        public virtual ICollection<VehicleReservation> VehicleReservations { get; set; }

        /// <summary>
        /// Nrt Vehicles
        /// </summary>
        public virtual ICollection<NrtVehicle> NrtVehicles { get; set; } 
        
        #endregion
    }
}
