using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Category Search Request Response Web Model
    /// </summary>
    public class VehicleCategorySearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Vehicle Categories List
        /// </summary>
        public IEnumerable<VehicleCategory> VehicleCategories { get; set; }

        /// <summary>
        /// Total Count of Vehicle Categories
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}