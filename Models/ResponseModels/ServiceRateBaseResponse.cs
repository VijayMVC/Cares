using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Rate Base Domain Response
    /// </summary>
    public sealed class ServiceRateBaseResponse
    {
          #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRateBaseResponse()
        {
            Operations = new List<Operation>();
            TariffTypes = new List<TariffType>();
        }
        #endregion
        
        #region Public
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }
        /// <summary>
        /// Tariff types
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        #endregion
    }
}
