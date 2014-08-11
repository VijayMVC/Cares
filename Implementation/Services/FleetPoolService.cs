using System;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
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
            FleetPool fleet=fleetPoolRepository.AddNewFleetPool(fleetPool);
            fleetPoolRepository.SaveChanges();
            return fleet;
        }
        /// <summary>
        /// Load Fleet Pool Base Data
        /// </summary>
        public FleetPoolBaseDataResponse LoadFleetPoolBaseData()
        {
            //TODO: Sample exception to be thrown. Uncomment to see the behavior
            //throw new CaresException("This is cares business exception");  
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
        /// <summary>
        /// update fleetpool 
        /// </summary>
        public FleetPool UpdateFleetPool(FleetPool fleetPool)
        {
            fleetPool.RecCreatedBy = fleetPoolRepository.LoggedInUserIdentity;
            fleetPool.RecCreatedDt = DateTime.Now;
            fleetPool.RecLastUpdatedBy = fleetPoolRepository.LoggedInUserIdentity;
            fleetPool.RecLastUpdatedDt = DateTime.Now;
            fleetPoolRepository.Update(fleetPool);
            fleetPoolRepository.SaveChanges();
            return fleetPoolRepository.Find(fleetPool.FleetPoolId);
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
