using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Nrt Type Search Request Response Domain model
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
