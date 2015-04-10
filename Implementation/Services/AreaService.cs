using System;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Area Service
    /// </summary>
    public class AreaService : IAreaService
    {
        #region Private
        private readonly ICityRepository cityRepository;
        private readonly IAreaRepository areaRepository;
        private readonly IAddressRepository addressRepository;

        /// <summary>
        /// Set newly created Area object Properties in case of adding
        /// </summary>
        private void SetAreaProperties(Area area, Area dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = areaRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.AreaCode = area.AreaCode;
            dbVersion.AreaName = area.AreaName;
            dbVersion.AreaDescription = area.AreaDescription;
            dbVersion.CityId = area.CityId;
            dbVersion.UserDomainKey = areaRepository.UserDomainKey;
        }

        /// <summary>
        /// update Area object Properties in case of updation
        /// </summary>
        private void UpdateAreaPropertie(Area area, Area dbVersion)
        {
            dbVersion.RecLastUpdatedBy = areaRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.AreaCode = area.AreaCode;
            dbVersion.AreaName = area.AreaName;
            dbVersion.AreaDescription = area.AreaDescription;
            dbVersion.CityId = area.CityId;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long areaId)
        {
            // Assocoation with address check 
            if (addressRepository.IsAreaAssociatedWithAddress(areaId))
                throw new CaresException(Resources.GeographicalHierarchy.Area.AreaIsAssociatedWithAddressError);

        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaService(ICityRepository cityRepository, IAreaRepository areaRepository, IAddressRepository addressRepository)
        {
            this.areaRepository = areaRepository;
            this.cityRepository = cityRepository;
            this.addressRepository = addressRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Areas
        /// </summary>
        public IEnumerable<Area> LoadAll()
        {
            return areaRepository.GetAll();
        }

        /// <summary>
        /// Load Area Base Data
        /// </summary>
        public AreaBaseDataResponse LoadAreaBaseData()
        {
            return new AreaBaseDataResponse
            {
                Cities = cityRepository.GetAll()
            };
        }

        /// <summary>
        /// Search Area
        /// </summary>
        public AreaSearchRequestResponse SearchArea(AreaSearchRequest request)
        {
            int rowCount;
            return new AreaSearchRequestResponse
            {
                Areas = areaRepository.SearchArea(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Area by id
        /// </summary>
        public void DeleteArea(long areaId)
        {
            Area dbversion = areaRepository.Find((int)areaId);
            ValidateBeforeDeletion(areaId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(Resources.GeographicalHierarchy.Area.AreaNotFoundInDatabase);
            }
            areaRepository.Delete(dbversion);
            areaRepository.SaveChanges();
        }

       // <summary>
        // Add /Update Area
        // </summary>
       public Area SaveArea(Area area)
        {
            Area dbVersion = areaRepository.Find(area.AreaId);
            //Code Duplication Check
            if (areaRepository.DoesAreaCodeExist(area))
                throw new CaresException(Resources.GeographicalHierarchy.Area.AreaCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateAreaPropertie(area, dbVersion);
                areaRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new Area();
                SetAreaProperties(area, dbVersion);
                areaRepository.Add(dbVersion);
            }
            areaRepository.SaveChanges();
            // To Load the proprties
            return areaRepository.LoadAreaWithDetail(dbVersion.AreaId);
        }
        #endregion
    }
}