using System;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Main Web Model
    /// </summary>
    public class NrtMain
    {
        #region Persisted Properties

        /// <summary>
        /// Nrt Main ID
        /// </summary>
        public long NrtMainId { get; set; }
        
        /// <summary>
        /// Operation Id 
        /// </summary>
        public long? OperationId { get; set; }

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
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Nrt Status
        /// </summary>
        public NrtVehicleMovement NrtStatusMovement { get; set; }

        /// <summary>
        /// Nrt Drivers
        /// </summary>
        public List<NrtDriver> NrtDrivers { get; set; }

        /// <summary>
        /// Nrt Charges
        /// </summary>
        public List<NrtCharge> NrtCharges { get; set; }

        /// <summary>
        /// Nrt Vehicle
        /// </summary>
        public List<NrtVehicle> NrtVehicles { get; set; }
        
       
        ///// <summary>
        ///// Chauffer Reservations
        ///// </summary>
        //public virtual ICollection<ChaufferReservation> ChaufferReservations { get; set; }

        #endregion
    }
}