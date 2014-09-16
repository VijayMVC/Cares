using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// TariffType Detail Response Response Model
    /// </summary>
    public class TariffTypeDetailResponse
    {
        public TariffType TariffType { get; set; }
        public List<TariffType> TariffTypeRevisions { get; set; }
        
    }
}


