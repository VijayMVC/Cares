using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Phone Type Domain Model
    /// </summary>
    public class PhoneType
    {
        #region Persisted Properties
        /// <summary>
        /// Phone Type ID
        /// </summary>
        public int PhoneTypeId { get; set; }
        /// <summary>
        /// PhoneType Code
        /// </summary>
        [StringLength(100)]
        public string PhoneTypeCode { get; set; }
        /// <summary>
        /// PhoneType Name
        /// </summary>
        [StringLength(255)]
        public string PhoneTypeName { get; set; }
        /// <summary>
        /// Phone Type Key
        /// </summary>
        public int? PhoneTypeKey { get; set; }
        /// <summary>
        /// PhoneType Description
        /// </summary>
        [StringLength(500)]
        public string PhoneTypeDescription { get; set; }
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
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Phones having this Phone Type
        /// </summary>
        public virtual ICollection<Phone> Phones { get; set; } 
        
        #endregion
    }
}
