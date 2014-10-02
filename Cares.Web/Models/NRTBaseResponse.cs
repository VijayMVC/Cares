using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// NRT Wb Base Response
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class NRTBaseResponse
    {
        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Operations Work Place
        /// </summary>
        public IEnumerable<OperationsWorkPlaceDropDown> Locations { get; set; }

        /// <summary>
        /// Non Revenue Tickect Types
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IEnumerable<NrtTypeDropDown> NRTTypes { get; set; }

        /// <summary>
        /// Vehicle Statuses
        /// </summary>
        public List<VehicleStatus> VehicleStatuses { get; set; }
    }
}