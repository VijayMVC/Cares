using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Vehicle Movement Web Model
    /// </summary>
    public class NrtVehicleMovement
    {
        #region Public Properties

        /// <summary>
        /// Nrt Vehicle ID
        /// </summary>
        public long NrtVehicleMovementId { get; set; }
        
        /// <summary>
        /// Vehicle Id
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Operations Workplace ID
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// DtTime
        /// </summary>
        public DateTime DtTime { get; set; }

        /// <summary>
        /// Odometer
        /// </summary>
        public int Odometer { get; set; }

        /// <summary>
        /// Fuel Level
        /// </summary>
        public double FuelLevel { get; set; }

        /// <summary>
        /// Vehicle Movement Description
        /// </summary>
        public string VehicleMovementDescription { get; set; }

        /// <summary>
        /// Movement Status
        /// </summary>
        public bool MovementStatus { get; set; }

        /// <summary>
        /// Vehicle Condition Description
        /// </summary>
        public string VehicleConditionDescription { get; set; }

        /// <summary>
        /// Vehicle Condition
        /// </summary>
        public string VehicleCondition { get; set; }
        #endregion
    }
}