
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Discount Sub Type Search Request Response Web Model
    /// </summary>
    public class DiscountSubTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Discount Sub Types List
        /// </summary>
        public IEnumerable<DiscountSubType> DiscountSubTypes { get; set; }

        /// <summary>
        /// Total Count of Discount Sub Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}