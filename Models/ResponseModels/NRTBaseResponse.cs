using System.Collections;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// NRT Base Response
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class NRTBaseResponse
    {
        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Operations Work Place
        /// </summary>
        public IEnumerable<OperationsWorkPlace> Locations { get; set; }

        /// <summary>
        /// Non Revenue Tickect Types
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public IEnumerable<NrtType> NRTTypes { get; set; }

        /// <summary>
        /// Vehicle Statuses
        /// </summary>
        public IEnumerable<VehicleStatus> VehicleStatuses { get; set; }
    }
}
