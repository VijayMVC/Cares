using System;

namespace Cares.Models.DomainModels
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
        /// Ra HireGroup Discount Description
        /// </summary>
        public string RaHireGroupDiscountDescription { get; set; }

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
        /// Ra Hire Group
        /// </summary>
        public virtual RaHireGroup RaHireGroup { get; set; }

        #endregion
    }
}
