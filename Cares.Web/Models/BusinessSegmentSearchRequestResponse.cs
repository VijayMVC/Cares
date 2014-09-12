using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Segment Search Request Response
    /// </summary>
    public class BusinessSegmentSearchRequestResponse
    {
         #region Public
        /// <summary>
        /// Business Segment List
        /// </summary>
        public IEnumerable<BusinessSegment> BusinessSegments { get; set; }

        /// <summary>
        /// Total Count of BusinessSegments
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}