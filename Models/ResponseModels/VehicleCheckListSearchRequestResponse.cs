using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Check List Search Request Response Domain model
    /// </summary>
    public class VehicleCheckListSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Vehicle Check Lists List
        /// </summary>
        public IEnumerable<VehicleCheckList> VehicleCheckLists { get; set; }

        /// <summary>
        /// Total Count of Vehicle CheckLists
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
