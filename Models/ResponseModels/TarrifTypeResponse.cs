using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Tarrif Type Response
    /// </summary>
    public sealed class TarrifTypeResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeResponse()
        {
            TarrifTypes = new List<TarrifType>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Tarrif Type
        /// </summary>
        public IEnumerable<TarrifType> TarrifTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
