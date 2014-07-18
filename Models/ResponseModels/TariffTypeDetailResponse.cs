using System.Collections.Generic;
using Models.DomainModels;
namespace Models.ResponseModels
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


