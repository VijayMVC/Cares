using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Model Searcg Request Response Domain Model
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
