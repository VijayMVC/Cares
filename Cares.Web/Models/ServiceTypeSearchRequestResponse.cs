using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Service Type Search Request Response Web Model
    /// </summary>
    public class ServiceTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Service Type List
        /// </summary>
        public IEnumerable<ServiceType> ServiceTypes { get; set; }

        /// <summary>
        /// Total Count of Service Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}