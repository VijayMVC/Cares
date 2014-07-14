﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Parnter Domain Model
    /// </summary>
    public class BusinessPartner
    {
        #region Persisted Properties
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [Required]
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Code
        /// </summary>
        [Required]
        [StringLength(100)]
        public string BusinessPartnerCode { get; set; }
        /// <summary>
        /// Business Partner Name
        /// </summary>
        [StringLength(255)]
        public string BusinessPartnerName { get; set; }
        /// <summary>
        /// Business Partnere descritpion
        /// </summary>
        [StringLength(500)]
        public string BusinessPartnerDesciption { get; set; }
        /// <summary>
        /// System Guarantor Check
        /// </summary>
        [Required]
        public bool IsSystemGuarantor { get; set; }
        /// <summary>
        /// System Guarantor ID
        /// </summary>
        public long SystemGuarantorId { get; set; }
        /// <summary>
        /// Non System Guarantor
        /// </summary>
        [StringLength(500)]
        public string NonSystemGuarantor { get; set; }
        /// <summary>
        /// Individual Check
        /// </summary>
        public bool IsIndividual { get; set; }
        /// <summary>
        /// Dealing Employee Id
        /// </summary>
        public long DealingEmployeeId { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }
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
        [Required]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [Required]
        [StringLength(100)]
        public String RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Business Partner Email Address
        /// </summary>
        [StringLength(100)]
        public string BusinessPartnerEmailAddress { get; set; }
        /// <summary>
        /// Business Partner Is Valid
        /// </summary>
        [Required]
        public bool BusinessPartnerIsValid { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties

        #endregion
    }
}
