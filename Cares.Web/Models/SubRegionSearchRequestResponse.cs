using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Sub-Region Search Request Response web model
    /// </summary>
    public class SubRegionSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Sub Regions List
        /// </summary>
        public IEnumerable<SubRegion> SubRegions { get; set; }

        /// <summary>
        /// Total Count of Sub Regions
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
