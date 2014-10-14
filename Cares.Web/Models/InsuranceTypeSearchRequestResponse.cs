using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Type Search Request Response Web model
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