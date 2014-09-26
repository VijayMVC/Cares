using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Type Search Request Response Web model
    /// </summary>
    public class NrtTypeSearchRequestResponse
    {

        #region Public
        /// <summary>
        /// Nrt Types List
        /// </summary>
        public IEnumerable<NrtType> NrtTypes { get; set; }

        /// <summary>
        /// Total Count of Nrt Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}