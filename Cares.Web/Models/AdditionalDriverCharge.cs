using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Additional Driver Charge Web Model
    /// </summary>
    public sealed class AdditionalDriverCharge
    {
        public long AdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Child Additional Driver Charge ID
        /// </summary>
         public long? ChildAdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
         public string TariffTypeCode { get; set; }

        /// <summary>
        /// Additional Driver Charge Rate
        /// </summary>
         public double AdditionalDriverChargeRate { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

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
    }
}