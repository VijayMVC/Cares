using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Designation Search Request Response domain model
    /// </summary>
    public class DesignationSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Designations List
        /// </summary>
        public IEnumerable<Designation> Designations { get; set; }

        /// <summary>
        /// Total Count of Designations
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
