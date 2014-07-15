using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Business Partner Response
    /// </summary>
    public sealed class BusinessPartnerResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerResponse()
        {
            BusinessPartners = new List<BusinessPartner>();
        }

        /// <summary>
        /// Business Partners
        /// </summary>
        public IEnumerable<BusinessPartner> BusinessPartners { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
