using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    public sealed class FleetPoolResponse
    {
        /// <summary>
        /// FleetPools
        /// </summary>
        public IEnumerable<FleetPool> Products { get; set; }

        /// <summary>
        /// FleetPool Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}