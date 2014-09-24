using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Standard Discount Main Domain Model
    /// </summary>
    public class StandardDiscountMain
    {
        #region Persisted Properties
        
        /// <summary>
        /// Standard Discount ID
        /// </summary>
        public long StandardDiscountMainId { get; set; }

        /// <summary>
        /// Standard Discount Code
        /// </summary>
        public string StandardDiscountMainCode { get; set; }

        /// <summary>
        /// Standard Discount Name
        /// </summary>
        public string StandardDiscountMainName { get; set; }

        /// <summary>
        /// Standard Discount Description
        /// </summary>
        public string StandardDiscountMainDescription { get; set; }

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
        /// Standard Discounts
        /// </summary>
        public virtual ICollection<StandardDiscount> StandardDiscounts { get; set; }

        #endregion
    }
}
