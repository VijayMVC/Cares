using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Document Group Search Request Response web model
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