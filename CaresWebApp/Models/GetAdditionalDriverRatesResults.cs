using System.Collections.Generic;

namespace Cares.WebApp.Models
{
    public class GetAdditionalDriverRatesResults
    {
        /// <summary>
        /// </summary>
        public IList<WebApiAdditionalDriverRates> WebApiAdditionalDriverRates { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}