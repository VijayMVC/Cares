using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Driver Charge Search Domain Response
    /// </summary>
    public class AdditionalDriverChargeSearchResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeSearchResponse()
        {
            AdditionalDriverCharges = new List<AdditionalDriverChargeSearchContent>();
        }

        /// <summary>
        /// Employees
        /// </summary>
        public IEnumerable<AdditionalDriverChargeSearchContent> AdditionalDriverCharges { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
