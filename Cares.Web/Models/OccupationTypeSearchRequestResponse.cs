using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Occupation Type Search Request Response Web model
    /// </summary>
    public class OccupationTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Occupation Type List
        /// </summary>
        public IEnumerable<OccupationType> OccupationTypes { get; set; }

        /// <summary>
        /// Total Count of Occupation Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}