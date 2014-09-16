using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Rate Base Web Response
    /// </summary>
    public class InsuranceRateBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRateBaseResponse()
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