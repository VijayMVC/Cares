using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Bp Main Type Search Request Response domain model
    /// </summary>
    public class BpMainTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        ///Business Partner Main Type List
        /// </summary>
        public IEnumerable<BusinessPartnerMainType> BpMainTypes { get; set; }

        /// <summary>
        /// Total Count of Business Partner Main Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
