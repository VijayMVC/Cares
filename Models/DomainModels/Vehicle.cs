using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Domain Model
    /// </summary>
    public class Vehicle
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Is Branch Owner
        /// </summary>
        public bool? IsBranchOwner { get; set; }

        /// <summary>
        /// Plate Number
        /// </summary>
        [StringLength(50)]
        public string PlateNumber { get; set; }

        /// <summary>
        /// Vehicle Code
        /// </summary>
        [StringLength(100), Required]
        public string VehicleCode { get; set; }
        
        /// <summary>
        /// Vehicle Name
        /// </summary>
        [StringLength(255)]
        public string VehicleName { get; set; }

        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }

        /// <summary>
        /// HireGroup ID
        /// </summary>
        [ForeignKey("HireGroup")]
        public long? HireGroupId { get; set; }

        /// <summary>
        /// FleetPool ID
        /// </summary>
        [ForeignKey("FleetPool")]
        public long? FleetPoolId { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [StringLength(50), Required]
        public string Color { get; set; }

        /// <summary>
        /// Operations WorkPlace ID
        /// </summary>
        [ForeignKey("OperationsWorkPlace")]
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
        [ForeignKey("VehicleMake")]
        public short VehicleMakeId { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        [ForeignKey("VehicleCategory")]
        public short VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        [ForeignKey("VehicleModel")]
        public short VehicleModelId { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        [ForeignKey("VehicleStatus")]
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Fuel Type ID
        /// </summary>
        [ForeignKey("FuelType")]
        public short FuelTypeId { get; set; }

        /// <summary>
        /// Transmission Type ID
        /// </summary>
        [ForeignKey("TransmissionType")]
        public short TransmissionTypeId { get; set; }

        /// <summary>
        /// Vehicle Condition
        /// </summary>
        [StringLength(255)]
        public string VehicleCondition { get; set; }

        /// <summary>
        /// Vehicle Condition Description
        /// </summary>
        [StringLength(1500)]
        public string VehicleConditionDescription { get; set; }

        /// <summary>
        /// Registration Expiry Date
        /// </summary>
        public DateTime? RegistrationExpiryDate { get; set; }

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
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }

        /// <summary>
        /// Fleet Pool
        /// </summary>
        public virtual FleetPool FleetPool { get; set; }

        /// <summary>
        /// Vehicle Make
        /// </summary>
        public virtual VehicleMake VehicleMake { get; set; }

        /// <summary>
        /// Vehicle Category
        /// </summary>
        public virtual VehicleCategory VehicleCategory { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public virtual VehicleModel VehicleModel { get; set; }

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public virtual VehicleStatus VehicleStatus { get; set; }

        /// <summary>
        /// Fuel Type
        /// </summary>
        public virtual FuelType FuelType { get; set; }

        /// <summary>
        /// Transmission Type
        /// </summary>
        public virtual TransmissionType TransmissionType { get; set; }

        /// <summary>
        /// OperationsWorkPlace
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlace { get; set; }

        /// <summary>
        ///Vehicle Other Detail assocaited to this Entity
        /// </summary>
        public virtual VehicleOtherDetail VehicleOtherDetail { get; set; }

        /// <summary>
        ///Vehicle Purchase Info assocaited to this Entity
        /// </summary>
        public virtual VehiclePurchaseInfo VehiclePurchaseInfo { get; set; }

        /// <summary>
        ///Vehicle Leased Info assocaited to this Entity
        /// </summary>
        public virtual VehicleLeasedInfo VehicleLeasedInfo { get; set; }

        /// <summary>
        ///Vehicle Insurance Info assocaited to this Entity
        /// </summary>
        public virtual VehicleInsuranceInfo VehicleInsuranceInfo { get; set; }

        /// <summary>
        ///Vehicle Depreciation assocaited to this Entity
        /// </summary>
        public virtual VehicleDepreciation VehicleDepreciation { get; set; }

        /// <summary>
        ///Vehicle Disposal Info assocaited to this Entity
        /// </summary>
        public virtual VehicleDisposalInfo VehicleDisposalInfo { get; set; }
        #endregion
    }
}
