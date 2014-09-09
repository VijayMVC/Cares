using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Insurance Info Web Model
    /// </summary>
    public sealed class VehicleInsuranceInfo
    {
        /// <summary>
        /// Vehicle Insurance Info Id
        /// </summary>
        public long VehicleInsuranceInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Insurance Agent
        /// </summary>
        public string InsuranceAgent { get; set; }

        /// <summary>
        /// Coverage Limit
        /// </summary>
        public int? CoverageLimit { get; set; }

        /// <summary>
        /// Renewal Date
        /// </summary>
        public DateTime? RenewalDate { get; set; }

        /// <summary>
        /// Insurance Date
        /// </summary>
        public DateTime? InsuranceDate { get; set; }

        /// <summary>
        /// Premium
        /// </summary>
        public float? Premium { get; set; }

        /// <summary>
        /// Insured Value
        /// </summary>
        public decimal? InsuredValue { get; set; }

        /// <summary>
        /// Insured From
        /// </summary>
        public string InsuredFrom { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
        public short? InsuranceTypeId { get; set; }

    }
}