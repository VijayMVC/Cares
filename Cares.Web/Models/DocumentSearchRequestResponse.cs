using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Document Search Request Response web model
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