using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Document Searc hRequest Response domain model
    /// </summary>
    public class DocumentSearchRequestResponse
    {

        #region Public
        /// <summary>
        /// Documents List
        /// </summary>
        public IEnumerable<Document> Documents { get; set; }

        /// <summary>
        /// Total Count of Documents
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
