using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class BusinessPartnerSubTypeSearchRequestResponse
    {
        /// <summary>
        /// Business Partner Sub Type Search Request Response Web model
        /// </summary>
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