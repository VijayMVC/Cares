using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Work Place Type Search Request Response
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