using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// RA Main For RA Queue Search Web Response
    /// </summary>
    public class RaMainForRaQueueSearchResponse
    {
        /// <summary>
        /// RA MAin
        /// </summary>
        public IEnumerable<RaMainForRaQueue> RaMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}