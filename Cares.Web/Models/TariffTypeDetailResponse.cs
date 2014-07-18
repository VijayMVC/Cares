using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class TariffTypeDetailResponse
    {
        public TariffTypeDetail TarrifType { get; set; }
        public IEnumerable<TariffTypeDetail> TarrifTypeRevisions { get; set; }
    }
}