﻿using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Type Detail Web Model
    /// </summary>
    public class TariffTypeDetail
    {
        #region Public Properties
        /// <summary>
        /// Tariff Type Id
        /// </summary>
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
          public string TariffTypeCode { get; set; }
        /// <summary>
        /// Tariff Type Name
        /// </summary>
          public string TariffTypeName { get; set; }
        /// <summary>
        /// Tariff Type Description
        /// </summary>
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
           public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
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
    }
}