using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Occupation Type Search Request Response Domain Model
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
