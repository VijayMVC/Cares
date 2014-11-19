using System.Collections.Generic;

namespace Cares.WebApp.Models
{
    public class GetAvailableInsurancesRatesResults
    {
        /// <summary>
        /// </summary>
        public IList<WebApiAvailableInsurancesRates> ApiAvailableInsurances { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}