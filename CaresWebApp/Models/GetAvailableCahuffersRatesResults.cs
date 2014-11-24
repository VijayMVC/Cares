using System.Collections.Generic;

namespace Cares.WebApp.Models
{
    public class GetAvailableCahuffersRatesResults
    {
        /// <summary>
        /// </summary>
        public IEnumerable<WebApiAvailableChuffersRates> ApiAvailableChuffersRates { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}