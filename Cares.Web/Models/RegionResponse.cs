using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// tariff Type Base Response Web Models
    /// </summary>
    public class RegionResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionResponse()
        {
            ResponseRejions = new List<RegionDropDown>();
        }
        #endregion
        #region Public
        /// <summary>
        /// rejions
        /// </summary>
        public IEnumerable<RegionDropDown> ResponseRejions { get; set; }
        #endregion
    }
}


