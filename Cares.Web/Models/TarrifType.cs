using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// tariff Type Web Models
    /// </summary>
    public class TariffType
    {
        #region Public Properties
        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }
        /// <summary>
        /// Measurement Unit
        /// </summary>
        public string MeasurementUnit { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }
        /// <summary>
        /// Tariff Type Name
        /// </summary>
        public string TariffTypeName { get; set; }
        /// <summary>
        /// Pricing Scheme
        /// </summary>
        public string PricingScheme { get; set; }
        /// <summary>
        /// Companay
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Operation
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// Duration To
        /// </summary>
        public short DurationTo { get; set; }
        /// <summary>
        /// Duration From
        /// </summary>
        public short DurationFrom { get; set; }
        /// <summary>
        /// Grace Period
        /// </summary>
        public float GracePeriod { get; set; }
        /// <summary>
        /// Effective Date
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        #endregion
    }
}