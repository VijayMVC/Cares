using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// RA HireGroup Discount Model
    /// </summary>
    public class RaHireGroupDiscount
    {
        #region Persisted Properties
        
        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaHireGroupDiscountId { get; set; }

        /// <summary>
        /// RA Hire Group Id
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Start Datetime
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Datetime
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Discount Percentage
        /// </summary>
        public double DiscountPerc { get; set; }

        /// <summary>
        /// Discount Amount
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Discout Days
        /// </summary>
        public int DiscountDays { get; set; }

        /// <summary>
        /// Discount Hour
        /// </summary>
        public int DiscountHours { get; set; }

        /// <summary>
        /// Discount Minute
        /// </summary>
        public int DiscountMinutes { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffType { get; set; }

        /// <summary>
        /// Discount Code
        /// </summary>
        public string DiscountCode { get; set; }

        /// <summary>
        /// Discout Key
        /// </summary>
        public short DiscountKey { get; set; }
        
        #endregion

    }
}