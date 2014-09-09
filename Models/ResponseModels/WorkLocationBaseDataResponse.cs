using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Work Location Base Data Response
    /// </summary>
    public class WorkLocationBaseDataResponse
    {
        /// <summary>
        /// List of companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }
        /// <summary>
        /// List of subregions
        /// </summary>
        public IEnumerable<SubRegion> SubRegions { get; set; }
        /// <summary>
        /// List of countries
        /// </summary>
        public IEnumerable<Country> Countries { get; set; }
        /// <summary>
        /// List of cities
        /// </summary>
        public IEnumerable<City> Cities { get; set; }

        /// <summary>
        /// list of regions
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }
        /// <summary>
        /// List of areas
        /// </summary>
        public IEnumerable<Area> Areas { get; set; }
        /// <summary>
        /// List of phone types
        /// </summary>
        public IEnumerable<PhoneType> PhoneTypes { get; set; }
    }
}
