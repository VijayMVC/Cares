
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// City Base Data Response web model
    /// </summary>
    public class CityBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<CountryDropDown> CountriyDropDowns { get; set; }

        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<RegionDropDown> RegionDropDowns { get; set; }

        /// <summary>
        /// Sub-Regions
        /// </summary>
        public IEnumerable<SubRegionDropDown> SubRegionDowns { get; set; }
        #endregion 
    }
}