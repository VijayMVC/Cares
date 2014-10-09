using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Maintenance Type Search Request Response Domain Model
    /// </summary>
   public class MaintenanceTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Maintenance Type List
        /// </summary>
       public IEnumerable<MaintenanceType> MaintenanceTypes { get; set; }

        /// <summary>
       /// Total Count of Maintenance Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
