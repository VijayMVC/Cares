using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Service Item Search Request Response Web model
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