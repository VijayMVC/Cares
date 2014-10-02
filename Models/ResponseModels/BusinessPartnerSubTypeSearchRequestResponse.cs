
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Business Partner Sub Type Search Request Response Domain model
    /// </summary>
    public class BusinessPartnerSubTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Business Partner Sub Types List
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> BusinessPartnerSubTypes { get; set; }

        /// <summary>
        /// Total Count of Business Partner SubTypes
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
