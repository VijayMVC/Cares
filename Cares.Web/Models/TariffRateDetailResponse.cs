using System.Collections.Generic;
using System.Linq;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Rate Detail Web Response
    /// </summary>
    public class TariffRateDetailResponse
    {
        /// <summary>
        /// Standard Rate Main
        /// </summary>
        public StandardRateMain StandardRateMain { get; set; }
        /// <summary>
        /// Hire Group Details List
        /// </summary>
        public IEnumerable<HireGroupDetail> HireGroupDetails { get; set; }
    }
}