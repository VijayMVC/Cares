using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle CheckList Search Request Response web model
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