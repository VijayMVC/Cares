using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Company Search Response web models
    /// </summary>
    public class CompanySearchRequestResponse
    {

        #region Public
        /// <summary>
        /// Cities List
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// Total Count of Cities
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}