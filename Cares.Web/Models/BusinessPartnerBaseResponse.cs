
using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class BusinessPartnerBaseResponse
    {
        #region Private
        #endregion
        //#region Constructors
        ///// <summary>
        ///// Constructor
        ///// </summary>
        //public BusinessPartnerBaseResponse()
        //{
        //    ResponseCompanies = new List<Company>();
        //    ResponsePaymentTerms = new List<PaymentTerm>();
        //    ResponseBPRatingTypes = new List<BpRatingType>();
        //    ResponseBusinessLegalStatuses = new List<BusinessLegalStatus>();
        //    ResponseBusinessPartners = new List<BusinessPartnerListView>();
        //    ResponseDealingEmployees = new List<Employee>();
        //}
        //#endregion
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
        #endregion
    }
}