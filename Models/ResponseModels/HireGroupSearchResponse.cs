using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Hire Group Search Response
    /// </summary>
    public sealed class HireGroupSearchResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupSearchResponse()
        {
            HireGroups = new List<HireGroup>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Hire Groups
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
