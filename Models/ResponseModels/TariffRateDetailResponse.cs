using System.Linq;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Tariff Rate Detail Response
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
        public IQueryable<HireGroupDetail> HireGroupDetails { get; set; }
    }
}
