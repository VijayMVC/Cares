using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Region Search Request Response domain model
    /// </summary>
    public class RegionSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Regions List
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// Total Count of Regions
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
