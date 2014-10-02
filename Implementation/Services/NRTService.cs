using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Non Revenue Ticket Service
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class NRTService : INRTService
    {
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly INrtTypeRepository nrtTypeRepository;
        private readonly IVehicleStatusRepository vehicleStatusRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public NRTService(IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            INrtTypeRepository nrtTypeRepository, IVehicleStatusRepository vehicleStatusRepository)
        {
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.nrtTypeRepository = nrtTypeRepository;
            this.vehicleStatusRepository = vehicleStatusRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Non Revenue Ticket Base data
        /// </summary>
        public NRTBaseResponse GetBaseData()
        {
            return new NRTBaseResponse
            {
                Operations = operationRepository.GetAll(),
                Locations = operationsWorkPlaceRepository.GetAll(),
                NRTTypes = nrtTypeRepository.GetAll(),
                VehicleStatuses = vehicleStatusRepository.GetAll(),
            };
        }
        #endregion
    }
}
