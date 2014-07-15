
using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tarrif Type
    /// </summary>
    public class TarrifType
    {
        public long TariffTypeId { get; set; }
        public long UserDomainKey { get; set; }
        public long OperationId { get; set; }
        public short MeasurementUnitId { get; set; }
        [MaxLength(100)]
        public string TariffTypeCode { get; set; }
        [StringLength(255)]
        public string TariffTypeName { get; set; }
        [MaxLength(500)]
        public string TariffTypeDescription { get; set; }
        public int PricingStrategyId { get; set; }
        public short DurationFrom { get; set; }
        public short DurationTo { get; set; }
        public float GracePeriod { get; set; }
        public DateTime EffectiveDate { get; set; }
        public long RowVersion { get; set; }
        public long RevisionNumber { get; set; }
        public long ChildTariffTypeId { get; set; }
        public DateTime RecCreatedDt { get; set; }
        public DateTime RecLastUpdatedDt { get; set; }
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        [MaxLength(100)]
        public string RecCreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsReadOnly { get; set; }
    }
}