using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Area Search Request Response domain model
    /// </summary>
    public class AreaSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Areas List
        /// </summary>
        public IEnumerable<Area> Areas { get; set; }

        /// <summary>
        /// Total Count of Areas
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
