using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Business Parnter Base Data Domain Model
    /// </summary>
    public class BusinessPartnerBaseDataResponse
    {
        #region Public Properties
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
        public IEnumerable<BusinessPartner> ResponseBusinessPartners { get; set; }
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
        /// Passport Countries
        /// </summary>
        public IEnumerable<Country> ResponsePassportCountries { get; set; }
        /// <summary>
        /// Business Segments
        /// </summary>
        public IEnumerable<BusinessSegment> ResponseBusinessSegments { get; set; }

        #endregion
    }
}
