using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Address Base Data Response entity
    /// </summary>
    public class AddressBaseResponse
    {
        #region Private
        #endregion

        #region Protected
        #endregion

        #region Public
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