
using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class BusinessPartnerBaseResponse
    {
        #region Private
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerBaseResponse()
        {
            ResponseCompanies = new List<Company>();
            ResponsePaymentTerms = new List<PaymentTerm>();
            ResponseBPRatingTypes = new List<BpRatingType>();
            ResponseBusinessLegalStatuses = new LinkedList<BusinessLegalStatus>();
        }
        #endregion
        #region Protected
        #endregion
        #region Public
      
        #endregion
    }
}