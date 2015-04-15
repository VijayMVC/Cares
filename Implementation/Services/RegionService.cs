using System;
using System.Collections.Generic;
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
    /// Region Service
    /// </summary>
    public class RegionService : IRegionService
    {
        #region Private
        private readonly IRegionRepository regionRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISubRegionRepository subRegionRepository;

        /// <summary>
        /// Set newly created Region object Properties in case of adding
        /// </summary>
        private void SetRegionProperties(Region region, Region dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.RegionCode = region.RegionCode;
            dbVersion.RegionName = region.RegionName;
            dbVersion.RegionDescription = region.RegionDescription;
            dbVersion.CountryId = region.CountryId;
            dbVersion.UserDomainKey = regionRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Region object Properties in case of updation
        /// </summary>
        protected void UpdateRegionPropertie(Region region, Region dbVersion)
        {
            dbVersion.RecLastUpdatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.RegionCode = region.RegionCode;
            dbVersion.RegionName = region.RegionName;
            dbVersion.RegionDescription = region.RegionDescription;
            dbVersion.CountryId = region.CountryId;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long regionId)
        {
            // Assocoation with city check 
            if (cityRepository.IsRegionAssociatedWithCity(regionId))
                throw new CaresException(Resources.GeographicalHierarchy.Region.RegionIsAssociatedWithCityError);

            // Assocoation with sub region check 
            if (subRegionRepository.IsRegionAssocistedWithSubRegion(regionId))
                throw new CaresException(Resources.GeographicalHierarchy.Region.RegionIsAssociatedWithSubRegionError);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionService(IRegionRepository regionRepository, ICountryRepository countryRepository, ICityRepository cityRepository, ISubRegionRepository subRegionRepository)
        {
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.subRegionRepository = subRegionRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Regions
        /// </summary>
        public IEnumerable<Region> LoadAll()
        {
            return regionRepository.GetAll();
        }

        /// <summary>
        /// Load Region Base Data
        /// </summary>
        public RegionBaseDataResponse LoadRegionBaseData()
        {
            return new RegionBaseDataResponse
            {
                Countries = countryRepository.GetAll()
            };
        }

        /// <summary>
        /// Search Region
        /// </summary>
        public RegionSearchRequestResponse SearchRegion(RegionSearchRequest request)
        {
            int rowCount;
            return new RegionSearchRequestResponse
            {
                Regions = regionRepository.SearchRegion(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Region by id
        /// </summary>
        public void DeleteRegion(long regionId)
        {
            Region dbversion = regionRepository.Find((int) regionId);
            ValidateBeforeDeletion(regionId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.GeographicalHierarchy.Region.RegionNotFoundInDatabase));
            }
            regionRepository.Delete(dbversion);
            regionRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update region
        /// </summary>
        public Region SaveRegion(Region region)
        {
            Region dbVersion = regionRepository.Find(region.RegionId);
            //Code Duplication Check
            if (regionRepository.DoesRegionCodeExist(region))
                throw new CaresException(Resources.GeographicalHierarchy.Region.RegionCodeDuplicationError); // doit

            if (dbVersion != null)
            {
                UpdateRegionPropertie(region, dbVersion);
                regionRepository.Update(dbVersion);
            }
            else
            {
                dbVersion=new Region();
                SetRegionProperties(region,dbVersion);
                regionRepository.Add(dbVersion);
            }
            regionRepository.SaveChanges();
            // To Load the proprties
            return regionRepository.LoadRegionWithDetail(dbVersion.RegionId);
        }

      
        #endregion
    }
}