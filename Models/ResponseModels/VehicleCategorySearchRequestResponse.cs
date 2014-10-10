using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Category Search Request Response Domain Model
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
