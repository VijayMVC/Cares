using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Discount Sub Type Domain Model
    /// </summary>
    public class DiscountSubType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Discount Sub Type ID
        /// </summary>
        public short DiscountSubTypeId { get; set; }

        /// <summary>
        /// Discount Type Id
        /// </summary>
        public short DiscountTypeId { get; set; }

        /// <summary>
        /// DiscountSubType Code
        /// </summary>
        public string DiscountSubTypeCode { get; set; }

        /// <summary>
        /// DiscountSubType Name
        /// </summary>
        public string DiscountSubTypeName { get; set; }

        /// <summary>
        /// DiscountSubType Description
        /// </summary>
        public string DiscountSubTypeDescription { get; set; }

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
        /// Discount Type
        /// </summary>
        public virtual DiscountType DiscountType { get; set; }

        #endregion
    }
}
