
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels 
{
    /// <summary>
    /// Business Legal Status Search Request Respose Domain Model
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
