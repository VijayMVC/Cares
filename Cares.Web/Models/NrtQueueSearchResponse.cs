using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Queue Search Web Response
    /// </summary>
    public sealed class NrtQueueSearchResponse
    {
        /// <summary>
        /// Nrt MAin
        /// </summary>
        public IEnumerable<NrtMainForNrtQueue> NrtMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}