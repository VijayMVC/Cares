using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{    /// <summary>
    /// Tarrif Type Domain Model
    /// </summary>
    public class TarrifType
    {
        [Key]
        public long TariffTypeId { get; set; }
        public long UserDomainKey { get; set; }
        public long OperationId { get; set; }
        public short MeasurementUnitId { get; set; }
        [StringLength(100)]
        public string TariffTypeCode { get; set; }
        [StringLength(255)]
        public string TariffTypeName { get; set; }
        [StringLength(500)]
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
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsReadOnly { get; set; }

        #region Reference Properties

        /// <summary>
        /// Operation
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Measurement Unit
        /// </summary>
        public virtual MeasurementUnit MeasurementUnit { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Pricing Strategy
        /// </summary>
        public virtual PricingStrategy PricingStrategy { get; set; }
        #endregion
    }
}
