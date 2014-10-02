using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Relation Type Search Request Response Web Model
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