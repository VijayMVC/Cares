
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Region Base Data Response
    /// </summary>
    public class RegionBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<Country> Countries { get; set; }
        #endregion 
    }
}
