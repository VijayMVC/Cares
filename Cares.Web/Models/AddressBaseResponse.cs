using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Address Base Data Response entity
    /// </summary>
    public class AddressBaseResponse
    {
        /// <summary>
        /// Country
        /// </summary>
        public CountryDropDown ResponseCountry { get; set; }
        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<RegionDropDown> ResponseRegions { get; set; }
        /// <summary>
        /// Sub Regions
        /// </summary>
        public IEnumerable<SubRegionDropDown> ResponseSubRegions { get; set; }
        /// <summary>
        /// Cities 
        /// </summary>
        public IEnumerable<CityDropDown> ResponseCities { get; set; }
        /// <summary>
        /// Areas
        /// </summary>
        public IEnumerable<AreaDropDown> ResponseAreas { get; set; }
    }
}