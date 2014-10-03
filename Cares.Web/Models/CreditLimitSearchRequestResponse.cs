using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Credit Limit Search Request Response WEb Model
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