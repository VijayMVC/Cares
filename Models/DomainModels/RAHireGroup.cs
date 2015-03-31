using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// RA HireGroup Model
    /// </summary>
    public class RaHireGroup
    {
        #region Persisted Properties
        
        /// <summary>
        /// RA HireGroup ID
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Allocation Status ID
        /// </summary>
        public short AllocationStatusId { get; set; }

        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long HireGroupDetailId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long? VehicleId { get; set; }

        /// <summary>
        /// Standard Rate
        /// </summary>
        public double StandardRate { get; set; }

        /// <summary>
        /// Allowed Mileage
        /// </summary>
        public int? AllowedMileage { get; set; }

        /// <summary>
        /// Drop off charge
        /// </summary>
        public double DropOffCharge { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Rental Charge Start Date
        /// </summary>
        public DateTime RentalChargeStartDate { get; set; }

        /// <summary>
        /// Rental Charge End Date
        /// </summary>
        public DateTime RentalChargeEndDate { get; set; }

        /// <summary>
        /// Total Standard Charge
        /// </summary>
        public double TotalStandardCharge { get; set; }

        /// <summary>
        /// Total Excess Mileage Charge
        /// </summary>
        public double TotalExcMileageCharge { get; set; }

        /// <summary>
        /// Total Excess Mileage
        /// </summary>
        public int TotalExcMileage { get; set; }

        /// <summary>
        /// Excess Mileage Rate
        /// </summary>
        public double ExcessMileageRt { get; set; }

        /// <summary>
        /// Grace Day
        /// </summary>
        public int GraceDay { get; set; }

        /// <summary>
        /// Grace Hour
        /// </summary>
        public int GraceHour { get; set; }

        /// <summary>
        /// Grace Minute
        /// </summary>
        public int GraceMinute { get; set; }

        /// <summary>
        /// Charged Day
        /// </summary>
        public int ChargedDay { get; set; }

        /// <summary>
        /// Charged Hour
        /// </summary>
        public int ChargedHour { get; set; }

        /// <summary>
        /// Charged Minute
        /// </summary>
        public int ChargedMinute { get; set; }
        
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
        /// RA Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Allocation Status
        /// </summary>
        public virtual AllocationStatus AllocationStatus { get; set; }

        /// <summary>
        /// RaHireGroup Discounts
        /// </summary>
        public virtual ICollection<RaHireGroupDiscount> RaHireGroupDiscounts { get; set; }

        /// <summary>
        /// RaHireGroup Insurances
        /// </summary>
        public virtual ICollection<RaHireGroupInsurance> RaHireGroupInsurances { get; set; }

        /// <summary>
        /// RaVehicle CheckLists
        /// </summary>
        public virtual ICollection<RaVehicleCheckList> RaVehicleCheckLists { get; set; }

        /// <summary>
        /// Vehicle Movements
        /// </summary>
        public virtual ICollection<VehicleMovement> VehicleMovements { get; set; }

        #endregion

        public short? AllocationStatusKey
        {
            get;
            set;
        }
    }
}
