using System;

namespace Cares.Models.DomainModels
{

    /// <summary>
    /// Vehicle Depreciation Domain Model
    /// </summary>
    public class VehicleDepreciation
    {
        #region Persisted Properties

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
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        #endregion
    }
}
