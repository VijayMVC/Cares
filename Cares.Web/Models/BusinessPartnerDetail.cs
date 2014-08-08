using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Api Detail Model
    /// </summary>
    public sealed class BusinessPartnerDetail
    {
        #region Public Properties

        #region Business Partner Properties
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
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
        /// Business Partner Email Address
        /// </summary>
        public string BusinessPartnerEmailAddress { get; set; }
        /// <summary>
        /// Business Partner Is Valid
        /// </summary>
        public bool BusinessPartnerIsValid { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// Payment Term Id
        /// </summary>
        public short PaymentTermId { get; set; }
        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
        public short? BPRatingTypeId { get; set; }
        /// <summary>
        /// System Guarantor ID
        /// </summary>
        public long? SystemGuarantorId { get; set; }
        /// <summary>
        /// Dealing Employee Id
        /// </summary>
        public long? DealingEmployeeId { get; set; }
        /// <summary>
        /// Business Legal Status Id
        /// </summary>
        public short? BusinessLegalStatusId { get; set; }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Business Partner Individual 
        /// </summary>
        public BusinessPartnerIndividual BusinessPartnerIndividual { get; set; }
        /// <summary>
        /// Business Partner Company 
        /// </summary>
        public BusinessPartnerCompany BusinessPartnerCompany { get; set; }
        /// <summary>
        /// Business Partner InTypes 
        /// </summary>
        public List<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }
        /// <summary>
        /// Business Partner Phones 
        /// </summary>
        public List<Phone> BusinessPartnerPhoneNumbers { get; set; }
        /// <summary>
        /// Business Partner Address List 
        /// </summary>
        public List<Address> BusinessPartnerAddressList { get; set; }
        #endregion

        #endregion
    }
}