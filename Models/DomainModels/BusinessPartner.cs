using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
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
        public string BusinessPartnerCode { get; set; }
        
        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerName { get; set; }
        
        /// <summary>
        /// Business Partnere descritpion
        /// </summary>
        public string BusinessPartnerDesciption { get; set; }
        
        /// <summary>
        /// System Guarantor Check
        /// </summary>
        public bool IsSystemGuarantor { get; set; }

        /// <summary>
        /// Non System Guarantor
        /// </summary>
        public string NonSystemGuarantor { get; set; }

        /// <summary>
        /// Individual Check
        /// </summary>
        public bool IsIndividual { get; set; }

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
        public String RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Business Partner Email Address
        /// </summary>
        public string BusinessPartnerEmailAddress { get; set; }

        /// <summary>
        /// Business Partner Is Valid
        /// </summary>
        public bool BusinessPartnerIsValid { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// System Guarantor ID
        /// </summary>
        public long? SystemGuarantorId { get; set; }

        /// <summary>
        /// Business Legal Status Id
        /// </summary>
        public short? BusinessLegalStatusId { get; set; }

        /// <summary>
        /// Dealing Employee Id
        /// </summary>
        public long? DealingEmployeeId { get; set; }

        /// <summary>
        /// Payment Term Id
        /// </summary>
        public short PaymentTermId { get; set; }

        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
// ReSharper disable once InconsistentNaming
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
        /// Business Partnet Individuals
        /// </summary>
        public virtual ICollection<BusinessPartnerIndividual> BusinessPartnerIndividuals { get; set; }
        
        /// <summary>
        /// Business Partner Company Info
        /// </summary>
        public virtual BusinessPartnerCompany BusinessPartnerCompany { get; set; }
        
        /// <summary>
        /// Business Partner In Types collection
        /// </summary>
        public virtual ICollection<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }
        
        /// <summary>
        /// Business Partner Phones
        /// </summary>
        public virtual ICollection<Phone> BusinessPartnerPhoneNumbers { get; set; }
        /// <summary>
        /// Business Partner Address List
        /// </summary>
        public virtual ICollection<Address> BusinessPartnerAddressList { get; set; }
        /// <summary>
        /// Business Partner Marketing Channels
        /// </summary>
        public virtual ICollection<BusinessPartnerMarketingChannel> BusinessPartnerMarketingChannels { get; set; }
        /// <summary>
        /// Business Partner RelationshipItems list
        /// </summary>
        public virtual ICollection<BusinessPartnerRelationship> BusinessPartnerRelationshipItemList { get; set; }

        /// <summary>
        /// Secondary Business Partner Relationships
        /// </summary>
        public virtual ICollection<BusinessPartnerRelationship> SecondaryBusinessPartnerRelationships { get; set; }

        /// <summary>
        /// Vehicle Purchase Infos
        /// </summary>
        public virtual ICollection<VehiclePurchaseInfo> VehiclePurchaseInfos { get; set; }

        /// <summary>
        /// Vehicle Insurance Infos
        /// </summary>
        public virtual ICollection<VehicleInsuranceInfo> VehicleInsuranceInfos { get; set; }

        /// <summary>
        /// Vehicle Leased Infos
        /// </summary>
        public virtual ICollection<VehicleLeasedInfo> VehicleLeasedInfos { get; set; }

        /// <summary>
        /// Vehicle Disposal Infos
        /// </summary>
        public virtual ICollection<VehicleDisposalInfo> VehicleDisposalInfos { get; set; }

        /// <summary>
        /// Ra Mains
        /// </summary>
        public virtual ICollection<RaMain> RaMains { get; set; }

        public virtual ICollection<BusinessPartnerDocument> BpDocuments { get; set; }


        #endregion
    }
}
