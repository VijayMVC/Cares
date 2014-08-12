using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// tariff Type Response Web Models
    /// </summary>
    public class TariffTypeSearchResponse
    { 
        
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeSearchResponse()
        {
            ServertariffTypes = new List<TariffType>();
        }
        #endregion
        
        #region Public
        /// <summary>
        /// tariff Types
        /// </summary>
        public IEnumerable<TariffType> ServertariffTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}