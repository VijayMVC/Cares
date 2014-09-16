using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Search Web Response
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