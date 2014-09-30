using System;
using System.Collections;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Seasonal Discount Main Web Model
    /// </summary>
    public class SeasonalDiscountMain
    {
        #region Public Properties

        /// <summary>
        /// Seasonal Discount ID
        /// </summary>
        public long SeasonalDiscountMainId { get; set; }

        /// <summary>
        /// Seasonal Discount Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Seasonal Discount Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Seasonal Discount Description
        /// </summary>
        public string Description { get; set; }

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

        #endregion

        #region Reference Properties

        /// <summary>
        /// Seasonal Discount
        /// </summary>
        //public IEnumerable<SeasonalDiscount> SeasonalDiscounts { get; set; }
        public IEnumerable<SeasonalDiscount> SeasonalDiscountList { get; set; }
        #endregion
    }
}