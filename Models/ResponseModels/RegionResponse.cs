using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Tarrif Type Base Response
    /// </summary>
    public sealed class RegionResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionResponse()
        {
            Regions = new List<Region>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }
       
        #endregion
    }
}
