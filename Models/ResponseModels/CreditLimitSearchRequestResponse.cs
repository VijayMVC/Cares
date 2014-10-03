using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Credit Limit Search Request Response Domain model
    /// </summary>
    public class CreditLimitSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Credit Limits List
        /// </summary>
        public IEnumerable<CreditLimit> CreditLimits { get; set; }

        /// <summary>
        /// Total Count of Credit Limits
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
