using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// BusinessPartnerRelationTypeSearchRequestResponse Domain Model
    /// </summary>
    public class BusinessPartnerRelationTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Business Partner Relationship Types List
        /// </summary>
        public IEnumerable<BusinessPartnerRelationshipType> BusinessPartnerRelationshipTypes { get; set; }

        /// <summary>
        /// Total Count of  Business Partner Relationship Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
