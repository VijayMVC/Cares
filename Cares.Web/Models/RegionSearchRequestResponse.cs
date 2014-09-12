using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Region Search Request Response web model
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