using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Sub region base data web model
    /// </summary>
    public class SubRegionBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Region
        /// </summary>
        public IEnumerable<RegionDropDown> RegionsDropDowns { get; set; }
        #endregion 
    }
}