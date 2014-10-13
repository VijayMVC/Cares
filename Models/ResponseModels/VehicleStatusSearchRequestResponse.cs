using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Status Search Request Response Domain Model
    /// </summary>
    public class VehicleStatusSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Vehicle Statuses List
        /// </summary>
        public IEnumerable<VehicleStatus> VehicleStatuses { get; set; }

        /// <summary>
        /// Vehicle Statuses Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
