using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Legal Status Domain Model
    /// </summary>
    public class BusinessLegalStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Business Legal Status ID
        /// </summary>
        public short BusinessLegalStatusId { get; set; }
        
        /// <summary>
        /// Business Legal Status Code
        /// </summary>
        [StringLength(100), Required]
        public string BusinessLegalStatusCode { get; set; }
        
        /// <summary>
        /// Business Legal Status Name
        /// </summary>
        [StringLength(255)]
        public string BusinessLegalStatusName { get; set; }

        /// <summary>
        /// Business Legal Status Description
        /// </summary>
        [StringLength(500)]
        public string BusinessLegalStatusDescription { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }
        
        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partners Associated to this
        /// </summary>
        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; }
        
        #endregion
    }
}
