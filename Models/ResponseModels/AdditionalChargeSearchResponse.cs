using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Charge Search Domain Response
    /// </summary>
    public sealed class AdditionalChargeSearchResponse
    {
          /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeSearchResponse()
        {
            AdditionalChargeTypes = new List<AdditionalChargeType>();
        }

        /// <summary>
        /// Additional Charge Types
        /// </summary>
        public IEnumerable<AdditionalChargeType> AdditionalChargeTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
