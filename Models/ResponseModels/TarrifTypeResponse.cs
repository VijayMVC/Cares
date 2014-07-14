

using System.Collections.Generic;
using Models.DomainModels;

namespace Models.ResponseModels
{
    /// <summary>
    /// Tarrif Type Response
    /// </summary>
    public sealed class TarrifTypeResponse
    {
        #region Private
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeResponse()
        {
            TarrifTypes = new List<TarrifType>();
        }
        #endregion
        #region Protected
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
