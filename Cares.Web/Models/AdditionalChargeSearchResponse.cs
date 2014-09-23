using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Additional Charge Search web Response 
    /// </summary>
    public class AdditionalChargeSearchResponse
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