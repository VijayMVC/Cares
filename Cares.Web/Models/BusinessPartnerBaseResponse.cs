using System.Collections.Generic;
using Cares.Models.DomainModels;

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
        public IEnumerable<PaymentTermDropDown> ResponsePaymentTerms { get; set; }
        /// <summary>
        /// Business Partner Payment Types 
        /// </summary>
        public IEnumerable<BpRatingTypeDropDown> ResponseBPRatingTypes { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<BusinessLegalStatusDropDown> ResponseBusinessLegalStatuses { get; set; }
        /// <summary>
        /// System Guarnator 
        /// </summary>
        public IEnumerable<BusinessPartnerListView> ResponseBusinessPartners { get; set; }
        /// <summary>
        /// Dealing Employees 
        /// </summary>
        public IEnumerable<EmployeeDropDown> ResponseDealingEmployees { get; set; }
        /// <summary>
        /// Occupation Types
        /// </summary>
        public IEnumerable<OccupationTypeDropDown> ResponseOccupationTypes { get; set; }
        /// <summary>
        /// Business Partner Companies 
        /// </summary>
        public IEnumerable<BusinessPartnerCompany> ResponseBusinessPartnerCompanies { get; set; }
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<CountryDropDown> ResponseCountries { get; set; }
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
        public IEnumerable<PhoneTypeDropDown> ResponsePhoneTypes { get; set; }
        /// <summary>
        /// Address Types
        /// </summary>
        public IEnumerable<AddressTypeDropDown> ResponseAddressTypes { get; set; }
        /// <summary>
        /// Marketing Channels
        /// </summary>
        public IEnumerable<MarketingChannelDropDown> ResponseMarketingChannels { get; set; }
        #endregion
    }
}