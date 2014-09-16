using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// City Search Request Response domain model
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
