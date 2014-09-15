using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Sub Region Base Data Response 
    /// </summary>
    public class SubRegionBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }
        #endregion 
    }
}
