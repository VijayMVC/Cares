using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Leased Info
    /// </summary>
    public sealed class VehicleLeasedInfo
    {
        /// <summary>
        /// Vehicle Leased Info Id
        /// </summary>
        public long VehicleLeasedInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Down Payment
        /// </summary>
        public decimal? DownPayment { get; set; }

        /// <summary>
        /// Leased Start Date
        /// </summary>
        public DateTime? LeasedStartDate { get; set; }

        /// <summary>
        /// Leased Finish Date
        /// </summary>
        public DateTime? LeasedFinishDate { get; set; }

        /// <summary>
        /// Monthly Payment
        /// </summary>
        public decimal? MonthlyPayment { get; set; }

        /// <summary>
        /// Purchased From
        /// </summary>
        public string LeasedFrom { get; set; }

        /// <summary>
        /// Interest Rate
        /// </summary>
        public double? InterestRate { get; set; }

        /// <summary>
        /// Prinicipal Payment
        /// </summary>
        public decimal? PrinicipalPayment { get; set; }

        /// <summary>
        /// First Payment Date
        /// </summary>
        public DateTime? FirstPaymentDate { get; set; }

        /// <summary>
        /// Last Month Payment
        /// </summary>
        public decimal? LastMonthPayment { get; set; }

        /// <summary>
        /// Lease To Ownership
        /// </summary>
        public bool? LeaseToOwnership { get; set; }

        /// <summary>
        /// First Month Payment
        /// </summary>
        public decimal? FirstMonthPayment { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }

    }
}