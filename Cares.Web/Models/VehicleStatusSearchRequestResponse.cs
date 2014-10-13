using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Status Search Request Response WEb model
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