using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{

    /// <summary>
    /// Vehicle Depreciation Domain Model
    /// </summary>
    public class VehicleDepreciation
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle Depreciation Id
        /// </summary>
        public long VehicleDepreciationId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Useful Period Start Date
        /// </summary>
        public DateTime? UsefulPeriodStartDate { get; set; }

        /// <summary>
        /// First Month Dep Amount
        /// </summary>
        public decimal? FirstMonthDepAmount { get; set; }

        /// <summary>
        ///Monthly Dep Amount
        /// </summary>
        public decimal? MonthlyDepAmount { get; set; }

        /// <summary>
        ///Last Month Dep Amount
        /// </summary>
        public decimal? LastMonthDepAmount { get; set; }

        /// <summary>
        /// Residual Value
        /// </summary>
        public decimal? ResidualValue { get; set; }

        /// <summary>
        /// Useful Period End Date
        /// </summary>
        public DateTime? UsefulPeriodEndDate { get; set; }

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
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
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
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        #endregion
    }
}
