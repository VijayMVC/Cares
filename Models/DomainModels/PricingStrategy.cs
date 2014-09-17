using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Pricing Strategy Domain Model
    /// </summary>
    public class PricingStrategy
    {
        #region Persisted Properties
        /// <summary>
        /// PricingStrategy ID
        /// </summary>
        public int PricingStrategyId { get; set; }
        /// <summary>
        /// PricingStrategy Code
        /// </summary>
        public string PricingStrategyCode { get; set; }
        /// <summary>
        /// PricingStrategy Name
        /// </summary>
        public string PricingStrategyName { get; set; }
        /// <summary>
        /// PricingStrategy Description
        /// </summary>
        public string PricingStrategyDescription { get; set; }
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
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
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
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// tariff Types having this Pricing Strategy
        /// </summary>
        public virtual ICollection<TariffType> TariffTypes { get; set; }

        #endregion
    }
}
