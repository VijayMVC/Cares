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
    /// Sub Region Service
    /// </summary>
    public class SubRegionService : ISubRegionService
    {
        #region Private
        private readonly IRegionRepository regionRepository;
        private readonly ISubRegionRepository subRegionRepository;
        private readonly ICityRepository cityRepository;

        /// <summary>
        /// Set newly created sub Region object Properties in case of adding
        /// </summary>
        private void SetSubRegionProperties(SubRegion region, SubRegion dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.SubRegionCode = region.SubRegionCode;
            dbVersion.SubRegionName = region.SubRegionName;
            dbVersion.SubRegionDescription = region.SubRegionDescription;
            dbVersion.RegionId = region.RegionId;
            dbVersion.UserDomainKey = regionRepository.UserDomainKey;
        }

        /// <summary>
        /// update  sub Region object Properties in case of updation
        /// </summary>
        protected void UpdateSubRegionPropertie(SubRegion region, SubRegion dbVersion)
        {
            dbVersion.RecLastUpdatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.SubRegionCode = region.SubRegionCode;
            dbVersion.SubRegionName = region.SubRegionName;
            dbVersion.SubRegionDescription = region.SubRegionDescription;
            dbVersion.RegionId = region.RegionId;
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SubRegionService(IRegionRepository regionRepository, ISubRegionRepository subRegionRepository, ICityRepository cityRepository)
        {
            this.regionRepository = regionRepository;
            this.subRegionRepository = subRegionRepository;
            this.cityRepository = cityRepository;
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
        /// Load Sub Region Base Data
        /// </summary>
        public SubRegionBaseDataResponse LoadSubRegionBaseData()
        {
            return new SubRegionBaseDataResponse
            {
                Regions = regionRepository.GetAll()
            };
        }

        /// <summary>
        /// Search Sub Region
        /// </summary>
        public SubRegionSearchRequestResponse SearchSubRegion(SubRegionSearchRequest request)
        {
            int rowCount;
            return new SubRegionSearchRequestResponse
            {
                SubRegions = subRegionRepository.SearchSubRegion(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete sub Region by id
        /// </summary>
        public void DeleteSubRegion(long subRegionId)
        {
            SubRegion dbversion = subRegionRepository.Find((int) subRegionId);

            // Assocoation with city check 
            if (cityRepository.IsSubRegionAssociatedWithCity(subRegionId))
                throw new CaresException(Resources.GeographicalHierarchy.SubRegion.SubRegionIsAssociatedWithCityError);

            if (dbversion == null)
            {
                throw new InvalidOperationException(Resources.GeographicalHierarchy.SubRegion.SubRegionNotFoundInDatabase);
            }
            subRegionRepository.Delete(dbversion);
            subRegionRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update sub region
        /// </summary>
        public SubRegion SaveSubRegion(SubRegion subRegion)
        {
            SubRegion dbVersion = subRegionRepository.Find(subRegion.SubRegionId);
            //Code Duplication Check
            if (subRegionRepository.DoesSubRegionCodeExist(subRegion))
                throw new CaresException(Resources.GeographicalHierarchy.SubRegion.SubRegionCodeDuplicationError);

            if (dbVersion != null)
            {
                UpdateSubRegionPropertie(subRegion, dbVersion);
                subRegionRepository.Update(dbVersion);
            }
            else
            {
                dbVersion=new SubRegion();
                SetSubRegionProperties(subRegion, dbVersion);
                subRegionRepository.Add(dbVersion);
            }
            subRegionRepository.SaveChanges();
            // To Load the proprties
            return subRegionRepository.LoadSubRegionWithDetail(dbVersion.SubRegionId);
        }

      
        #endregion
    }
}