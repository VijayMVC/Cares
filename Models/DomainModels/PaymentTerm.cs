using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Payment Term Domain Model
    /// </summary>
    public class PaymentTerm
    {
        #region Persisted Properties
        /// <summary>
        /// PaymentTerm ID
        /// </summary>
        public short PaymentTermId { get; set; }
        /// <summary>
        /// PaymentTerm Code
        /// </summary>
        [StringLength(100), Required]
        public string PaymentTermCode { get; set; }
        /// <summary>
        /// PaymentTerm Name
        /// </summary>
        [StringLength(255)]
        public string PaymentTermName { get; set; }
        /// <summary>
        /// PaymentTerm Description
        /// </summary>
        [StringLength(500)]
        public string PaymentTermDescription { get; set; }
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
        /// Business Partners having this Payment Term
        /// </summary>
        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; } 
        
        #endregion
    }
}
