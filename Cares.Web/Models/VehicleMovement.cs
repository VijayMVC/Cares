using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Movement Model
    /// </summary>
    public class VehicleMovement
    {
        #region Persisted Properties

        /// <summary>
        ///  Vehicle ID
        /// </summary>
        public long VehicleMovementId { get; set; }

        /// <summary>
        /// Operations Workplace ID
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        ///  Ra HireGroup ID
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short? VehicleStatusId { get; set; }

        /// <summary>
        /// DtTime
        /// </summary>
        public DateTime DtTime { get; set; }

        /// <summary>
        /// Odometer
        /// </summary>
        public int? Odometer { get; set; }

        /// <summary>
        /// Fuel Level
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }

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