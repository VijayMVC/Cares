using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Fleet Pool Base Data Response
    /// </summary>
    public class FleetPoolBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Regions
        /// </summary>
        public IEnumerable<RegionDropDown> Regions { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }


        /// <summary>
        ///countires
        /// </summary>
        public IEnumerable<CountryDropDown> Countries { get; set; }

        #endregion
    }
}