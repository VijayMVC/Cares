using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// WorkPlaceType search request response
    /// </summary>
    public class WorkPlaceTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// WorkPlaceType List
        /// </summary>
        public IEnumerable<WorkPlaceType> WorkPlaceTypes { get; set; }

        /// <summary>
        /// Total Count of WorkPlaceTypes
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
