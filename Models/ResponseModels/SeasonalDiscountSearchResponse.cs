using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    ///  Seasonal Discount Search Domain Response
    /// </summary>
    public sealed class SeasonalDiscountSearchResponse
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
