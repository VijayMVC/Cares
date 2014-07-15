using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class TarrifTypeResponse
    { 
        #region Private
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeResponse()
        {
            ServerTarrifTypes = new List<TarrifType>();
        }
        #endregion
        #region Protected
        #endregion
        #region Public
        /// <summary>
        /// Tarrif Type
        /// </summary>
        public IEnumerable<TarrifType> ServerTarrifTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}