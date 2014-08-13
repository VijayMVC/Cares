using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// tariff Type Response
    /// </summary>
    public sealed class TariffTypeResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeResponse()
        {
            TariffTypes = new List<TariffType>();
        }
        #endregion
        #region Public
        /// <summary>
        /// tariff Type
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
