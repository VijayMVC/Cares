using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Discount Type Search Request Response
    /// </summary> 
    public class DiscountTypeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Discount Type List
        /// </summary>
        public IEnumerable<DiscountType> DiscountTypes { get; set; }

        /// <summary>
        /// Total Count of Discount Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}