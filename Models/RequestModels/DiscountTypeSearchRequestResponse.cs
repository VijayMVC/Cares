
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Discount  Type Search Request Response Domain model
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
