using System.Collections.Generic;

namespace Cares.Models.ResponseModels
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
            TariffRates = new List<TariffRateContent>();
        }
        #endregion
        
        #region Public
        /// <summary>
        /// tariff Rates
        /// </summary>
        public IEnumerable<TariffRateContent> TariffRates { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
