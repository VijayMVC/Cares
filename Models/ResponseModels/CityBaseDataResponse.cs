using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// City Base Data Response Domain model
    /// </summary>
    public class CityBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<Country> Countries { get; set; }

        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// Sub-Regions
        /// </summary>
        public IEnumerable<SubRegion> SubRegions { get; set; }
        #endregion 
    }
}
