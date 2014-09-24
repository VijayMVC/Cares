
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Discount Sub Type Search Request Response Domain model
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
