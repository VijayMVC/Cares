using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Credit Limit Base Data Response Web model
    /// </summary>
    public class CreditLimitBaseDataResponse
    {
        /// <summary>
        /// List of Business Partner Sub Types
        /// </summary>
        public IEnumerable<BusinessPartnerSubTypeDropDown> BusinessPartnerSubTypes { get; set; }

        /// <summary>
        /// List of Bp Rating Types
        /// </summary>
        public IEnumerable<BpRatingTypeDropDown> BpRatingTypes { get; set; }
    }
}