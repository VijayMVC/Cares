using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Depreciation Web Model
    /// </summary>
    public sealed class VehicleDepreciation
    {
        /// <summary>
        /// Vehicle Depreciation Id
        /// </summary>
        public long VehicleDepreciationId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
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

    }
}