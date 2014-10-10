using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// InsuranceTypeSearchRequestResponse Domain Model
    /// </summary>
    public class InsuranceTypeSearchRequestResponse
    {
        #region Public

        /// <summary>
        /// Insurance Type List
        /// </summary>
        public IEnumerable<InsuranceType> InsuranceTypes { get; set; }

        /// <summary>
        /// Total Count of Insurance Types
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
