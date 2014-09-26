using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Chauffer Charge Search Domain Response
    /// </summary>
    public sealed class ChaufferChargeSearchResponse
    {
        /// <summary>
        ///  Chauffer Charge Mains
        /// </summary>
        public IEnumerable<ChaufferChargeMainContent> ChaufferChargeMains { get; set; }


        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
