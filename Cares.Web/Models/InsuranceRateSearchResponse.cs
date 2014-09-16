using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Rate Search Web Response
    /// </summary>
    public sealed class InsuranceRateSearchResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRateSearchResponse()
        {
            InsuranceRtMains = new List<InsuranceRtMainContent>();
        }
        #endregion

        #region Public
        /// <summary>
        /// Insurance Rates
        /// </summary>
        public IEnumerable<InsuranceRtMainContent> InsuranceRtMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}