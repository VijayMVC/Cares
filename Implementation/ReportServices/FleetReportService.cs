using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.ReportModels;
using System.Collections.Generic;

namespace Cares.Implementation.ReportServices
{
    /// <summary>
    /// 
    /// </summary>
    public class FleetReportService : IFleetReportService
    {
        #region Private

        private readonly IVehicleRepository vehicleRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public FleetReportService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        #endregion
        #region Public

        public IList<RptFleetHireGroupDetail> LoadFleetHireGroupDetail()
        {
            return vehicleRepository.GetFleetReport();

        }

        #endregion

    }
}
