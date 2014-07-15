using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tarrif Type
    /// </summary>
    public class TarrifType
    {
        /// <summary>
        /// 
        /// </summary>
        public long TariffTypeId { get; set; }
        public string MeasurementUnit { get; set; }
        public string TariffTypeCode { get; set; }
        public string TariffTypeName { get; set; }
        public string PricingScheme { get; set; }
        public string Companay { get; set; }
        public string Operation { get; set; }
        public short DurationTo { get; set; }
        public short DurationFrom { get; set; }
        public float GracePeriod { get; set; }
        public DateTime EffectiveDate { get; set; }        
        public long RevisionNumber { get; set; }
    }
}