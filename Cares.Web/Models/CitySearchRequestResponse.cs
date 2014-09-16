using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// City Search Request Response web model
    /// </summary>
    public class CitySearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Cities List
        /// </summary>
        public IEnumerable<City> Cities { get; set; }

        /// <summary>
        /// Total Count of Cities
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}