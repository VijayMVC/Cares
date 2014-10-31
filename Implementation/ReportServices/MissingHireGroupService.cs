using System.Collections.Generic;
using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.ReportModels;

namespace Cares.Implementation.ReportServices
{
    /// <summary>
    /// 
    /// </summary>
    public class MissingHireGroupService : IMissingHireGroupService
    {
        #region Private

        private readonly IVehicleRepository vehicleRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MissingHireGroupService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        #endregion
        #region Public

        public IList<MissingHireGroupResponse> LoadMissingHireGroups()
        {
            return vehicleRepository.GetMissingHireGroups();
        }
        #endregion

    }
}
