using System.Linq;
using Cares.Commons;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// FleetPool Service
    /// </summary>
    public sealed class FleetPoolService : IFleetPoolService
    {
       #region Private
       
        private readonly IOperationRepository operationRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IRegionRepository regionRepository;
        private readonly IFleetPoolRepository fleetPoolRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;

        #endregion
       #region Constructors
         /// <summary>
         /// Constructors
         /// </summary>
         public FleetPoolService(
             IOperationRepository operationRepository, ICountryRepository countryRepository,
             IRegionRepository regionRepository, IFleetPoolRepository fleetPoolRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
         {
             this.operationRepository = operationRepository;
             this.countryRepository = countryRepository;
             this.regionRepository = regionRepository;
             this.fleetPoolRepository = fleetPoolRepository;
             this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
         }

         #endregion
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
                 Operations = operationRepository.GetSalesOperation(),
                 Regions = regionRepository.GetAll(),
                 Countries = countryRepository.GetAll()
             };
         }

         /// <summary>
         /// Delete FleetPool
         /// </summary>
         public void DeleteFleetPool(long fleetPoolId)
         {
             FleetPool dbVersion = FindFleetPool(fleetPoolId);
                 if (dbVersion == null)
                 {
                     throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                         "FleetPool with Id {0} not found!", fleetPoolId));
                 }
             //Association check
            if(operationsWorkPlaceRepository.IsOperationWorkPlaceAssociatedWithFleetPool(fleetPoolId))
            throw new CaresException(Resources.FleetPool.FleetPool.FleetPoolIsAssociatedWithOperationWorkPlaceError);

                 fleetPoolRepository.Delete(dbVersion);
                 fleetPoolRepository.SaveChanges();
         }

         /// <summary>
         /// Find FleetPool by id
         /// </summary>
         public FleetPool FindFleetPool(long fleetPoolId)
         {
             return fleetPoolRepository.Find(fleetPoolId);

         }

         /// <summary>
         /// update fleetpool 
         /// </summary>
         public FleetPool SaveFleetPool(FleetPool fleetPool)
         {
             FleetPool fleetPoolDbVersion = fleetPoolRepository.Find(fleetPool.FleetPoolId);
             // To check the code availability 
             if (!fleetPoolRepository.IsFleetPoolCodeExists(fleetPool))
             {
                 if (fleetPoolDbVersion == null) //Add Case
                 {
                     int numberOfFleetPoolsByDomainKey = fleetPoolRepository.GetCountOfFleetPoolWithDomainKey();
                     var domainLicenseDetailwithDomainKey = ClaimHelper.GetDeserializedClaims<DomainLicenseDetailClaim>(CaresUserClaims.DomainLicenseDetail).FirstOrDefault();
                     if (domainLicenseDetailwithDomainKey != null)
                         if (domainLicenseDetailwithDomainKey.FleetPools < numberOfFleetPoolsByDomainKey)
                             throw new CaresException(Resources.FleetPool.FleetPool.ExceedingDomainLimitForFleetPoolError);
                         else
                             throw new InvalidOperationException(Resources.FleetPool.FleetPool.NoDomainLicenseDetailClaim);
                     fleetPool.IsActive = true;
                     fleetPool.IsDeleted = fleetPool.IsPrivate = fleetPool.IsReadOnly = false;
                     fleetPool.RecLastUpdatedBy = fleetPool.RecCreatedBy = fleetPoolRepository.LoggedInUserIdentity;
                     fleetPool.RecCreatedDt = fleetPool.RecLastUpdatedDt = DateTime.Now;
                     fleetPool.RowVersion = 0;
                     fleetPool.UserDomainKey = fleetPoolRepository.UserDomainKey;
                     fleetPoolRepository.Add(fleetPool);
                 }
                 else //Update Case
                 {
                     fleetPoolDbVersion.FleetPoolCode = fleetPool.FleetPoolCode;
                     fleetPoolDbVersion.FleetPoolName = fleetPool.FleetPoolName;
                     fleetPoolDbVersion.FleetPoolDescription = fleetPool.FleetPoolDescription;
                     fleetPoolDbVersion.RecLastUpdatedDt = DateTime.Now;
                     fleetPoolDbVersion.RegionId = fleetPool.RegionId;
                     fleetPoolDbVersion.OperationId = fleetPool.OperationId;
                     fleetPoolDbVersion.RecLastUpdatedBy = fleetPoolRepository.LoggedInUserIdentity;
                     fleetPoolDbVersion.RowVersion = fleetPoolDbVersion.RowVersion + 1;
                 }
                 fleetPoolRepository.SaveChanges();
                 return fleetPoolRepository.GetFleetPoolWithDetails(fleetPool.FleetPoolId);
             }
             throw new CaresException(Resources.FleetPool.FleetPool.FleetPoolWithSameCodeAlreadyExistsError);
         }
         #endregion 
    }
}
