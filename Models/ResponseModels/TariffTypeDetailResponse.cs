using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// TariffType Detail Response Response Model
    /// </summary>
    public class TariffTypeDetailResponse
    {
        public TarrifType TarrifType { get; set; }
        public List<TarrifType> TarrifTypeRevisions { get; set; }
        
    }
}


