using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Make Search Request Response Domain Model
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
