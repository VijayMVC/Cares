using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Company Search Request Response Domain model
    /// </summary>
    public class CompanySearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Companies List
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

      /// <summary>
        /// Total Count of Companies
      /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
