using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Search Api Response
    /// </summary>
    public sealed class BusinessPartnerSearchResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerSearchResponse()
        {
            BusinessPartners = new List<BusinessPartnerListView>();
        }
        /// <summary>
        /// Business Partners
        /// </summary>
        public IEnumerable<BusinessPartnerListView> BusinessPartners { get; set; }
        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}