using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Work Locations Serach response
    /// </summary>
    public class WorkLocationSerachRequestResponse
    {
        #region Public
        /// <summary>
        /// Work Locations List
        /// </summary>
        public IEnumerable<WorkLocation> WorkLocations { get; set; }

        /// <summary>
        /// Total Count of WorkLocations
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}