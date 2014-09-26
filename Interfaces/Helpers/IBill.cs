using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Helpers
{
    /// <summary>
    /// Bill Engine Interface
    /// </summary>
    public interface IBill
    {
        /// <summary>
        /// Calculate Bill
        /// </summary>
        void CalculateBill(ref RaMain raMain, List<TariffType> oTariffTypeList);

    }
}
