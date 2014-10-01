using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// BusinessLegalStatusSearchRequestRespose Web model
    /// </summary>
    public class BusinessLegalStatusSearchRequestRespose
    {
        #region Public
        /// <summary>
        /// Business Legal Status List
        /// </summary>
        public IEnumerable<BusinessLegalStatus> BusinessLegalStatuses { get; set; }

        /// <summary>
        /// Total Count of Business Legal Statuses
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}