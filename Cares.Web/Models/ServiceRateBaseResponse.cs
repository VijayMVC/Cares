using System.Collections.Generic;

namespace Cares.Web.Models
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
            Operations = new List<OperationDropDown>();
            TariffTypes = new List<TariffTypeDropDown>();
        }
        #endregion

        #region Public
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }
        /// <summary>
        /// Tariff types
        /// </summary>
        public IEnumerable<TariffTypeDropDown> TariffTypes { get; set; }

        #endregion
    }
}