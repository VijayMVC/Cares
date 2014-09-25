using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Chauffer Charge Search Web Response
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