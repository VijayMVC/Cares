using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{    /// <summary>
    /// Tarrif Type Domain Model
    /// </summary>
    public class TarrifType
    {
        #region Persisited Properties
        /// <summary>
        /// Tariff Type Id
        /// </summary>
        [Key]
        public long TariffTypeId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Measurement Unit Id
        /// </summary>
        public int MeasurementUnitId { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        [StringLength(100)]
        public string TariffTypeCode { get; set; }
        /// <summary>
        /// Tariff Type Name
        /// </summary>
        [StringLength(255)]
        public string TariffTypeName { get; set; }
        /// <summary>
        /// Tariff Type Description
        /// </summary>
        [StringLength(500)]
        public string TariffTypeDescription { get; set; }
        /// <summary>
        /// Pricing Strategy Id
        /// </summary>
        public int PricingStrategyId { get; set; }
        /// <summary>
        /// Duration From
        /// </summary>
        public short DurationFrom { get; set; }
        /// <summary>
        /// Duration To
        /// </summary>
        public short DurationTo { get; set; }
        /// <summary>
        /// Grace Period
        /// </summary>
        public float GracePeriod { get; set; }
        /// <summary>
        /// Effective Date
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        /// <summary>
        /// Child Tariff Type Id
        /// </summary>
        public long ChildTariffTypeId { get; set; }
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
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        #endregion
        #region Reference Properties

        /// <summary>
        /// Operation
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Measurement UnitPricingStrategyId
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
