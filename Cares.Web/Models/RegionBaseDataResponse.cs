
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Region Base Data Response [web model]
    /// </summary>
    public class RegionBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<CountryDropDown> Countries { get; set; }
        #endregion 
    }
}
