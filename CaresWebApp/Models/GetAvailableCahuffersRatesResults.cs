using System.Collections.Generic;

namespace Cares.WebApp.Models
{
    public class GetAvailableCahuffersRatesResults
    {
        /// <summary>
        /// </summary>
        public IList<WebApiAvailableChuffersRates> ApiAvailableChuffersRates { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}