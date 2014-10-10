using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Vehicle Web Model
    /// </summary>
    public class NrtVehicle
    {

        #region Public Properties

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// NRT Main ID
        /// </summary>
        public long NrtMainId { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// NRT Vehicle Movements
        /// </summary>
        public List<NrtVehicleMovement> NrtVehicleMovements { get; set; }

        /// <summary>
        /// NRT Charges
        /// </summary>
        public List<NrtCharge> NrtCharges { get; set; }

        /// <summary>
        /// NRT Drivers
        /// </summary>
        public List<NrtDriver> NrtDrivers { get; set; }

        /// <summary>
        /// Nrt Main
        /// </summary>
        public NrtMain NrtMain { get; set; }

        #endregion
    }
}