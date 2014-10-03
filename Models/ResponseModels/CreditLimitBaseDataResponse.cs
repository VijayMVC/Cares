using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Credit Limit Base Data Response Domain model
    /// </summary>
    public class CreditLimitBaseDataResponse
    {
        /// <summary>
        /// List of Business Partner Sub Types
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> BusinessPartnerSubTypes { get; set; }

        /// <summary>
        /// List of Bp Rating Types
        /// </summary>
        public IEnumerable<BpRatingType> BpRatingTypes { get; set; }
    }
}
