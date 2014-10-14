using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Ra Main For Ra Queue Search Response
    /// </summary>
    public class RaMainForRaQueueSearchResponse
    {
        /// <summary>
        /// RA MAin
        /// </summary>
        public IEnumerable<RaMain> RaMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
