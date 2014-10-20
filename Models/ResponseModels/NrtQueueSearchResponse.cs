using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// NRTQueue Search Response
    /// </summary>
    public class NrtQueueSearchResponse
    {
        /// <summary>
        /// Nrt MAin
        /// </summary>
        public IEnumerable<NrtMain> NrtMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
