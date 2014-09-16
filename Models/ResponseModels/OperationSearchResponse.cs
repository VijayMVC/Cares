using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Operation Search request response
    /// </summary>
   public sealed class OperationSearchResponse
    {
        #region Public
        /// <summary>
        /// Operations Data
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// FleetPools Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
