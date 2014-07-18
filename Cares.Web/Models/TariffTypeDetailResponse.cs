using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Type Detail Response
    /// </summary>
    public class TariffTypeDetailResponse
    {
        public TariffTypeDetail TarrifType { get; set; }
        public IEnumerable<TariffTypeDetail> TarrifTypeRevisions { get; set; }
    }
}