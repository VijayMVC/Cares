using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Job  Type  Search Request Response Web Model
    /// </summary>
    public class JobTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Job Types List
        /// </summary>
        public IEnumerable<JobType> JobTypes { get; set; }

        /// <summary>
        /// Total Count of JobTypes
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
} 