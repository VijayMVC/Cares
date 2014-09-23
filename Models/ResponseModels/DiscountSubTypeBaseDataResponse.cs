
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Discount Sub Type Base Data Response Domain model
    /// </summary>
    public class DiscountSubTypeBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Discount Types
        /// </summary>
        public IEnumerable<DiscountType> DiscountTypes { get; set; }
        #endregion 
    }
}
