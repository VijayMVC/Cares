
using System.Collections.Generic;

namespace Cares.WebApp.Models
{
    /// <summary>
    /// get Services Result
    /// </summary>
    public class GetServicesResult
    {
        /// <summary>
        /// Web Api Insurance
        /// </summary>
        public IList<WebApiInsurance> Insurances { get; set; }

        /// <summary>
        /// Web Api Service Rate
        /// </summary>
        public IList<WebApiServiceRate> ServiceRates { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}