using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Model Searcg Request Response Web Model
    /// </summary>
    public class VehicleModelSearcgRequestResponse
    {
        #region Public
        /// <summary>
        /// Vehicle Models List
        /// </summary>
        public IEnumerable<VehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// Total Count of Vehicle Models
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}