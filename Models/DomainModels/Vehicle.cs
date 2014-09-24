using System;
using System.Collections.Generic;

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
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
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

        /// <summary>
        /// Vehicle Maintenance Type Frequency List
        /// </summary>
        public virtual ICollection<VehicleMaintenanceTypeFrequency> VehicleMaintenanceTypeFrequencies { get; set; }

        /// <summary>
        /// Vehicle Check List Items
        /// </summary>
        public virtual ICollection<VehicleCheckListItem> VehicleCheckListItems { get; set; }

        /// <summary>
        /// Vehicle Reservations
        /// </summary>
        public virtual ICollection<VehicleReservation> VehicleReservations { get; set; }

        /// <summary>
        /// Nrt Vehicles
        /// </summary>
        public virtual ICollection<NrtVehicle> NrtVehicles { get; set; }

        /// <summary>
        /// Ra HireGroups
        /// </summary>
        public virtual ICollection<RaHireGroup> RaHireGroups { get; set; }

        #endregion
    }
}
