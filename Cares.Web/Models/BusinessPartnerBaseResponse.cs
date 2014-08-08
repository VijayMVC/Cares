using System.Collections.Generic;
namespace Cares.Web.Models
{
    public class BusinessPartnerBaseResponse
    {
        #region Private
        #endregion

        #region Protected
        #endregion

        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> ResponseCompanies { get; set; }
        /// <summary>
        /// Payment Terms
        /// </summary>
        public IEnumerable<PaymentTerm> ResponsePaymentTerms { get; set; }
        /// <summary>
        /// Business Partner Payment Types 
        /// </summary>
        public IEnumerable<BpRatingType> ResponseBPRatingTypes { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<BusinessLegalStatus> ResponseBusinessLegalStatuses { get; set; }
        /// <summary>
        /// System Guarnator 
        /// </summary>
        public IEnumerable<BusinessPartnerListView> ResponseBusinessPartners { get; set; }
        /// <summary>
        /// Dealing Employees 
        /// </summary>
        public IEnumerable<Employee> ResponseDealingEmployees { get; set; }
        /// <summary>
        /// Occupation Types
        /// </summary>
        public IEnumerable<OccupationType> ResponseOccupationTypes { get; set; }
        /// <summary>
        /// Business Partner Companies 
        /// </summary>
        public IEnumerable<BusinessPartnerCompany> ResponseBusinessPartnerCompanies { get; set; }
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<Country> ResponseCountries { get; set; }
        /// <summary>
        /// Business Segments
        /// </summary>
        public IEnumerable<BusinessSegment> ResponseBusinessSegments { get; set; }
        /// <summary>
        /// Business Partner SubTypes
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> ResponseBusinessPartnerSubTypes { get; set; }
        /// <summary>
        /// Phone Types
        /// </summary>
        public IEnumerable<PhoneType> ResponsePhoneTypes { get; set; }
        /// <summary>
        /// Address Types
        /// </summary>
        public IEnumerable<AddressType> ResponseAddressTypes { get; set; }
        #endregion
    }
}