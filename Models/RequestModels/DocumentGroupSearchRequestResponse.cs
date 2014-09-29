using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Document Group Search Request Response Domain Model
    /// </summary>
    public class DocumentGroupSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Document Group List
        /// </summary>
        public IEnumerable<DocumentGroup> DocumentGroups { get; set; }

        /// <summary>
        /// Total Count of Document Groups
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
