using System;
using System.Globalization;
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
        /// Load All Fleet Pools meeting criteria
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
        /// Add new FleetPools
        /// </summary>
        public FleetPool AddNewFleetPool(FleetPool fleetPool) //later
        {
            fleetPool.RecCreatedBy = fleetPoolRepository.LoggedInUserIdentity;
            fleetPool.RecCreatedDt = DateTime.Now;
            fleetPool.RecLastUpdatedBy = fleetPoolRepository.LoggedInUserIdentity;
            fleetPool.RecLastUpdatedDt = DateTime.Now;
            FleetPool result = fleetPoolRepository.AddNewFleetPool(fleetPool);
            fleetPoolRepository.SaveChanges();
            return result;
        }
        /// <summary>
        /// Load Fleet Pool Base Data
        /// </summary>
        public FleetPoolBaseDataResponse LoadFleetPoolBaseData()
        {
            return new FleetPoolBaseDataResponse
            {
                Operations = operationRepository.GetSalesOperation(),
                Regions = regionRepository.GetAll(),
                Countries = countryRepository.GetAll()
            };
        }
        /// <summary>
        /// Delete FleetPool
        /// </summary>
        public void DeleteFleetPool(int id)
        {
            FleetPool dbVersion = FindFleetPool(id);
            if (dbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "FleetPool with Id {0} not found!", id));
            }
            fleetPoolRepository.Delete(dbVersion);
            fleetPoolRepository.SaveChanges();
        }
        /// <summary>
        /// Find FleetPool by id
        /// </summary>
        public FleetPool FindFleetPool(int id)
        {
            return fleetPoolRepository.Find(id);
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
       
        private readonly IOperationRepository operationRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IRegionRepository regionRepository;
         private readonly IFleetPoolRepository fleetPoolRepository;

        #endregion

        #region Constructors

        public FleetPoolService(
            IOperationRepository operationRepository, ICountryRepository countryRepository,
            IRegionRepository regionRepository, IFleetPoolRepository fleetPoolRepository)
        {
            this.operationRepository = operationRepository;
            this.countryRepository = countryRepository;
            this.regionRepository = regionRepository;
            this.fleetPoolRepository = fleetPoolRepository;
        }

        #endregion
    }
}
