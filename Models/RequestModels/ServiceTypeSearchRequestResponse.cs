using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Service Type Search Request Response domain model
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
