using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// FleetPool Web Response
    /// </summary>
    public sealed class FleetPoolResponse
    {
        #region Public
        /// <summary>
        /// FleetPools List
        /// </summary>
        public IEnumerable<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion

    }
}
