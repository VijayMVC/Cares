using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Search Web Response
    /// </summary>
    public sealed class GetVehicleResponse
    {
        #region Public
        
        /// <summary>
        /// Vehicles
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }

        #endregion
    }
}