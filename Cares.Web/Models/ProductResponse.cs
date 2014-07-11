using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Product Response
    /// </summary>
    public sealed class ProductResponse
    {
        
        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
