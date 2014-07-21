using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Tariff Rate Domain Response Model
    /// </summary>
    public sealed class TariffRateResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffRateResponse()
        {
            TariffRates = new List<StandardRateMain>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Tarrif Rates
        /// </summary>
        public IEnumerable<StandardRateMain> TariffRates { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
