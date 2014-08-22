using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Search Rate Search Domain Response
    /// </summary>
    public sealed class ServiceRateSearchResponse
    {

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRateSearchResponse()
        {
            ServiceRtMains = new List<ServiceRtMainContent>();
        }
        #endregion

        #region Public
        /// <summary>
        /// Service Rate Mains
        /// </summary>
        public IEnumerable<ServiceRtMainContent> ServiceRtMains { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
