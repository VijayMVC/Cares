using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    public class BookingMainSearchResponse
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