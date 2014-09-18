using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Area Search Request Response Web model
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