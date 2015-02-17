using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Web Model
    /// </summary>
    public class Vehicle
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

        /// <summary>
        /// Vehicle Category
        /// </summary>
        public VehicleCategoryDropDown VehicleCategory { get; set; }

        /// <summary>
        /// Vehicle Make
        /// </summary>
        public VehicleMakeDropDown VehicleMake { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public VehicleModelDropDown VehicleModel { get; set; }

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public VehicleStatus VehicleStatus { get; set; }

        /// <summary>
        /// Fleet Pool
        /// </summary>
        public FleetPool FleetPool { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        public OperationDropDown Operation { get; set; }

        /// <summary>
        /// OperationsWorkPlace
        /// </summary>
        public OperationsWorkPlace OperationsWorkPlace { get; set; }

        /// <summary>
        /// Fuel Type
        /// </summary>
        public FuelType FuelType { get; set; }

        /// <summary>
        /// Transmission Type
        /// </summary>
        public TransmissionType TransmissionType { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Image Source
        /// </summary>
        public string ImageSource
        {
            get
            {
                if (Image == null)
                {
                    return string.Format("data:{0};base64,{1}", "image/jpg", "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");

                }

                string base64 = Convert.ToBase64String(Image);
                return string.Format("data:{0};base64,{1}", "image/jpg", base64);
            }
        }

        /// <summary>
        /// Vehicle Make Code Name
        /// </summary>
        public string VehicleMakeCodeName { get; set; }

        /// <summary>
        /// Vehicle Model Code Name
        /// </summary>
        public string VehicleModelCodeName { get; set; }

        /// <summary>
        /// Vehicle Category Code Name
        /// </summary>
        public string VehicleCategoryCodeName { get; set; }

        /// <summary>
        /// Vehicle Status Code Name
        /// </summary>
        public string VehicleStatusCodeName { get; set; }
        #endregion
       
    }
}