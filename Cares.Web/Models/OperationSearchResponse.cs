using System.Collections.Generic;

namespace Cares.Web.Models
{
    public sealed class OperationSearchResponse
    {

        /// <summary>
        /// FleetPools
        /// </summary>
        public IEnumerable<Operation> Operations{ get; set; }

        /// <summary>
        /// FleetPool Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}