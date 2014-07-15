using System.Collections.Generic;

namespace Cares.Web.Models
{
    public sealed class FleetPoolResponse
    {
        /// <summary>
        /// FleetPools
        /// </summary>
        public IEnumerable<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// FleetPool Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}