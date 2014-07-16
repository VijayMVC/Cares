using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Fleet Pool Base Data Response
    /// </summary>
    public class FleetPoolBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Regions
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        #endregion
    }
}