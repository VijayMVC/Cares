using System.Collections.Generic;

namespace Cares.Web.Models
{/// <summary>
    /// Tariff Rate Web Response Model
    /// </summary>
    public sealed class TariffRateSearchResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffRateSearchResponse()
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