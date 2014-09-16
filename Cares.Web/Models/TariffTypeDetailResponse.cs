using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Type Detail Response
    /// </summary>
    public class TariffTypeDetailResponse
    {
        public TariffTypeDetail TariffType { get; set; }
        public IEnumerable<TariffTypeDetail> TariffTypeRevisions { get; set; }
    }
}