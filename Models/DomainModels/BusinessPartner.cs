using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Non System Guarantor
        /// </summary>
        [StringLength(500)]
        public string NonSystemGuarantor { get; set; }

        /// <summary>
        /// Individual Check
        /// </summary>
        [Required]
        public bool IsIndividual { get; set; }

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
        [StringLength(100)]
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

        /// <summary>
        /// Company Id
        /// </summary>
        [ForeignKey("Company"), Required]
        public long CompanyId { get; set; }

        /// <summary>
        /// System Guarantor ID
        /// </summary>
        [ForeignKey("SystemGuarantor")]
        public long? SystemGuarantorId { get; set; }

        /// <summary>
        /// Business Legal Status Id
        /// </summary>
        [ForeignKey("BusinessLegalStatus")]
        public short? BusinessLegalStatusId { get; set; }

        /// <summary>
        /// Dealing Employee Id
        /// </summary>
        [ForeignKey("DealingEmployee")]
        public long? DealingEmployeeId { get; set; }

        /// <summary>
        /// Payment Term Id
        /// </summary>
        [ForeignKey("PaymentTerm"), Required]
        public short PaymentTermId { get; set; }

        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
        [ForeignKey("BPRatingType")]
        public short? BPRatingTypeId { get; set; }

        #endregion

        #region Reference Properties
        
        /// <summary>
        /// Company reference
        /// </summary>
        public virtual Company Company { get; set; }
        
        /// <summary>
        /// System Guarantor
        /// </summary>
        public virtual BusinessPartner SystemGuarantor { get; set; }
        
        /// <summary>
        /// Payment Term reference
        /// </summary>
        public virtual PaymentTerm PaymentTerm { get; set; }
        
        /// <summary>
        /// Business Partner Rating Type reference
        /// </summary>
        public virtual BpRatingType BPRatingType { get; set; }
        
        /// <summary>
        /// Business Legal Status
        /// </summary>
        public virtual BusinessLegalStatus BusinessLegalStatus { get; set; }
        
        /// <summary>
        /// Dealing Employee
        /// </summary>
        public virtual Employee DealingEmployee { get; set; }
        
        /// <summary>
        /// Business Partnet Individual Info
        /// </summary>
        public virtual BusinessPartnerIndividual BusinessPartnerIndividual { get; set; }
        
        /// <summary>
        /// Business Partner Company Info
        /// </summary>
        public virtual BusinessPartnerCompany BusinessPartnerCompany { get; set; }
        
        /// <summary>
        /// Business Partner In Types collection
        /// </summary>
        public virtual ICollection<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }
        
        /// <summary>
        /// Business Partner In Types Phones
        /// </summary>
        public virtual ICollection<Phone> BusinessPartnerPhoneNumbers { get; set; }

        #endregion
    }
}
