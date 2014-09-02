using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle web Detail
    /// </summary>
    public sealed class VehicleDetail
    {

        #region Public Properties

        /// <summary>
        /// Vehicle Id
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Is Branch Owner
        /// </summary>
        public bool? IsBranchOwner { get; set; }

        /// <summary>
        /// Plate Number
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Vehicle Code
        /// </summary>
        public string VehicleCode { get; set; }

        /// <summary>
        /// Vehicle Name
        /// </summary>
        public string VehicleName { get; set; }

        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }

        /// <summary>
        /// HireGroup ID
        /// </summary>
        public long? HireGroupId { get; set; }

        /// <summary>
        /// FleetPool ID
        /// </summary>
        public long? FleetPoolId { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Operations WorkPlace ID
        /// </summary>
        public long? OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Fuel Level
        /// </summary>
        public short? FuelLevel { get; set; }

        /// <summary>
        /// Tank Size
        /// </summary>
        public short TankSize { get; set; }

        /// <summary>
        /// Initial Odometer
        /// </summary>
        public int InitialOdometer { get; set; }

        /// <summary>
        /// Current Odometer
        /// </summary>
        public int CurrentOdometer { get; set; }

        /// <summary>
        /// Registration Date
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short VehicleModelId { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Fuel Type ID
        /// </summary>
        public short FuelTypeId { get; set; }

        /// <summary>
        /// Transmission Type ID
        /// </summary>
        public short TransmissionTypeId { get; set; }

        /// <summary>
        /// Operation ID
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Vehicle Condition
        /// </summary>
        public string VehicleCondition { get; set; }

        /// <summary>
        /// Vehicle Condition Description
        /// </summary>
        public string VehicleConditionDescription { get; set; }

        /// <summary>
        /// Registration Expiry Date
        /// </summary>
        public DateTime? RegistrationExpiryDate { get; set; }
        
        #endregion


    }
}