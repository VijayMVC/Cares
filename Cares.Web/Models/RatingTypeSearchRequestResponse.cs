using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// web model
    /// </summary>
    public class RatingTypeSearchRequestResponse
    {
         #region Public
        /// <summary>
        /// Rating Types List
        /// </summary>
        public IEnumerable<BpRatingType> RatingTypes { get; set; }

        /// <summary>
        /// Total Count of Rating Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
    
}