using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Model for Fleet pool base data Response
    /// </summary>
    public sealed class FleetPoolBaseDataResponse
    {
        /// <summary>
        /// List of Region
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Country> Countries { get; set; }
    }
}
