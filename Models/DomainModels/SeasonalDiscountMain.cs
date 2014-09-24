using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Seasonal Discount Main Domain Model
    /// </summary>
    public class SeasonalDiscountMain
    {
        #region Persisted Properties
        
        /// <summary>
        /// Seasonal Discount ID
        /// </summary>
        public long SeasonalDiscountMainId { get; set; }

        /// <summary>
        /// Seasonal Discount Code
        /// </summary>
        public string SeasonalDiscountMainCode { get; set; }

        /// <summary>
        /// Seasonal Discount Name
        /// </summary>
        public string SeasonalDiscountMainName { get; set; }

        /// <summary>
        /// Seasonal Discount Description
        /// </summary>
        public string SeasonalDiscountMainDescription { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDt { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        
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
        /// Seasonal Discounts
        /// </summary>
        public virtual ICollection<SeasonalDiscount> SeasonalDiscounts { get; set; }

        #endregion
    }
}
