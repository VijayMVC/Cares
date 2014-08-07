using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tarrif Type Base Response Web Models
    /// </summary>
    public class RegionResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionResponse()
        {
            ResponseRejions = new List<Region>();
        }
        #endregion
        #region Public
        /// <summary>
        /// rejions
        /// </summary>
        public IEnumerable<Region> ResponseRejions { get; set; }
        #endregion
    }
}


