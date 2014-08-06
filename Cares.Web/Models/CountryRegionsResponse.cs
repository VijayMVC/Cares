using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// FleetPool Web Response
    /// </summary>
    public sealed class CountryRegionsResponse
    {
        #region Public
        /// <summary>
        /// FleetPools List
        /// </summary>
        public IEnumerable<global::Models.DomainModels.Region> Regions { get; set; }

        #endregion

    }
}
