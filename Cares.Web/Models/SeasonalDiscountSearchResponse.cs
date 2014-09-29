using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Seasonal Discount Search Web Response
    /// </summary>
    public class SeasonalDiscountSearchResponse
    {
        /// <summary>
        ///  Seasonal Discount Mains
        /// </summary>
        public IEnumerable<SeasonalDiscountMainContent> SeasonalDiscountMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}