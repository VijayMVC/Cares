using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Product Response
    /// </summary>
    public sealed class ProductResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductResponse()
        {
            Products = new List<Product>();
        }

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
