using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Discount Type Domain Model
    /// </summary>
    public class DiscountType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Discount Type ID
        /// </summary>
        public short DiscountTypeId { get; set; }

        /// <summary>
        /// Discount Type Code
        /// </summary>
        public string DiscountTypeCode { get; set; }

        /// <summary>
        /// Discount Type Name
        /// </summary>
        public string DiscountTypeName { get; set; }

        /// <summary>
        /// Discount Type Description
        /// </summary>
        public string DiscountTypeDescription { get; set; }
        
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
        /// Discount Sub Types
        /// </summary>
        public virtual ICollection<DiscountSubType> DiscountSubTypes { get; set; }

        #endregion
    }
}
