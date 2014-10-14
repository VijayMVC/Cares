using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Make Search Request Response web model
    /// </summary>
    public class VehicleMakeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Vehicle Makes List
        /// </summary>
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }

        /// <summary>
        /// Total Count of Vehicle Makes
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}