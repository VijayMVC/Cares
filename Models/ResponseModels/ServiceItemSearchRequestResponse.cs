using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Item Search Request Response Domain Model
    /// </summary>
    public class ServiceItemSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Service Items List
        /// </summary>
        public IEnumerable<ServiceItem> ServiceItems { get; set; }

        /// <summary>
        /// Total Count of Service Items
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
