using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Search Response
    /// </summary>
    public sealed class GetVehicleResponse
    {
        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public GetVehicleResponse()
        {
            Vehicles = new List<Vehicle>();
        }

        #endregion

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
