using System;
using System.Collections.Generic;

namespace Cares.Web.Models
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
        /// Allocation Status Key
        /// </summary>
        public short? AllocationStatusKey { get; set; }

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
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Allocation Status
        /// </summary>
        public AllocationStatus AllocationStatus { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public HireGroupDetailContent HireGroupDetail { get; set; }

        /// <summary>
        /// RaHireGroup Discounts
        /// </summary>
        public IEnumerable<RaHireGroupDiscount> RaHireGroupDiscounts { get; set; }

        /// <summary>
        /// RaHireGroup Insurances
        /// </summary>
        public IEnumerable<RaHireGroupInsurance> RaHireGroupInsurances { get; set; }

        /// <summary>
        /// RaVehicle CheckLists
        /// </summary>
        public IEnumerable<RaVehicleCheckList> RaVehicleCheckLists { get; set; }

        /// <summary>
        /// Vehicle Movements
        /// </summary>
        public IEnumerable<VehicleMovement> VehicleMovements { get; set; }

        #endregion
    }
}