using System.Collections.Generic;
namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Rate Web Response
    /// </summary>
    public class TariffRateResponse
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