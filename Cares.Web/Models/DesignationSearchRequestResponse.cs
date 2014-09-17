using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Designation Search Request Response web model
    /// </summary>
    public class DesignationSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Designation List
        /// </summary>
        public IEnumerable<Designation> Designations { get; set; }

        /// <summary>
        /// Total Count of Designations
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}