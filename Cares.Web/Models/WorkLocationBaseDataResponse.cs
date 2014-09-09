using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Work Location Base Data response class
    /// </summary>
    public class WorkLocationBaseDataResponse
    {
        #region Public

        /// <summary>
        /// Companies DropDown
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// Countries DropDown
        /// </summary>
        public IEnumerable<CountryDropDown> Countries { get; set; }

        /// <summary>
        /// Regions DropDown
        /// </summary>
        public IEnumerable<RegionDropDown> Regions { get; set; }

        /// <summary>
        /// Sub Regions DropDown
        /// </summary>
        public IEnumerable<SubRegionDropDown> SubRegions { get; set; }

        /// <summary>
        /// Cities DropDown
        /// </summary>
        public IEnumerable<CityDropDown> Cities { get; set; }

        /// <summary>
        /// Areas DropDown
        /// </summary>
        public IEnumerable<AreaDropDown> Areas { get; set; }

        /// <summary>
        /// Phone Type Dropdown
        /// </summary>
        public IEnumerable<PhoneTypeDropDown> PhoneTypes { get; set; }

        #endregion
    }
}