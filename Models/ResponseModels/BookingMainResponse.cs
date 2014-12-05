using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    public class BookingMainResponse
    {
        /// <summary>
        /// BookingMain List
        /// </summary>
        public IEnumerable<BookingMain> BookingMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
