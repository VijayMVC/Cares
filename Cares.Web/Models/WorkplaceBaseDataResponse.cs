using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Workplace Base Data Response
    /// </summary>
    public class WorkplaceBaseDataResponse
    {
        #region Public

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// WorkPlace Types DropDown
        /// </summary>
        public IEnumerable<WorkplaceTypeDropDown> WorkPlaceTypes { get; set; }

        /// <summary>
        /// Operation DropDown
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Work Locations DropDown
        /// </summary>
        public IEnumerable<WorkLocationDropDown> WorkLocations { get; set; }

        /// <summary>
        /// Fleet Pool DropDown
        /// </summary>
        public IEnumerable<FleetPoolDropDown> FleetPools { get; set; }

        #endregion
    }
}