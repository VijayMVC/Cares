using System.Collections.Generic;
using Cares.Models.DomainModels;
using Models.DomainModels;
namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Address Base Data Domain Model
    /// </summary>
    public class AddressBaseDataResponse
    {
        #region Public Properties
        /// <summary>
        /// Country
        /// </summary>
        public Country ResponseCountry { get; set; }
        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<Region> ResponseRegions { get; set; }
        /// <summary>
        /// Sub Regions
        /// </summary>
        public IEnumerable<SubRegion> ResponseSubRegions { get; set; }
        /// <summary>
        /// Cities 
        /// </summary>
        public IEnumerable<City> ResponseCities { get; set; }
        /// <summary>
        /// Areas
        /// </summary>
        public IEnumerable<Area> ResponseAreas { get; set; }
        #endregion
    }
}
