using System;
using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// FleetPool Service
    /// </summary>
    public sealed class FleetPoolService : IFleetPoolService
    {
        #region Public
        /// <summary>
        /// Load All Fleet Pools
        /// </summary>
        public FleetPoolResponse SerchFleetPool(FleetPoolSearchRequest searchRequest)
        {
            int rowCount;
            return new FleetPoolResponse
            {
                FleetPools = fleetPoolRepository.SearchFleetPool(searchRequest, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Load Fleet Pool Base Data
        /// </summary>
        public FleetPoolBaseDataResponse LoadFleetPoolBaseData()
        {
            return new FleetPoolBaseDataResponse
            {
                Operations = operationRepository.GetAll(),
                Regions = regionRepository.GetAll()
            };
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FleetPoolService(IFleetPoolRepository iFleetPoolRepositoryService, IRegionRepository regionRepository, IOperationRepository operationRepository)
        {
            if (iFleetPoolRepositoryService == null) throw new ArgumentNullException("iFleetPoolRepositoryService");
            if (regionRepository == null) throw new ArgumentNullException("regionRepository");
            if (operationRepository == null) throw new ArgumentNullException("operationRepository");

            fleetPoolRepository = iFleetPoolRepositoryService;
            this.regionRepository = regionRepository;
            this.operationRepository = operationRepository;
        }

        #endregion

        #region Private
        private readonly IFleetPoolRepository fleetPoolRepository;
        private readonly IRegionRepository regionRepository;
        private readonly IOperationRepository operationRepository;

        #endregion
    }
}
