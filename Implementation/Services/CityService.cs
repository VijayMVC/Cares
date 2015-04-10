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
    /// City Service
    /// </summary>
    public class CityService : ICityService
    {
        #region Private
        private readonly IRegionRepository regionRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISubRegionRepository subRegionRepository;
        private readonly IAreaRepository areaRepository;

        /// <summary>
        /// Set newly created City object Properties in case of adding
        /// </summary>
        private void SetCityProperties(City city, City dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.CityCode = city.CityCode;
            dbVersion.CityName = city.CityName;
            dbVersion.CityDescription = city.CityDescription;
            dbVersion.CountryId = city.CountryId;
            dbVersion.RegionId = city.RegionId;
            dbVersion.SubRegionId = city.SubRegionId;
            dbVersion.UserDomainKey = regionRepository.UserDomainKey;
        }

        /// <summary>
        /// update City object Properties in case of updation
        /// </summary>
        protected void UpdateCityPropertie(City city, City dbVersion)
        {
            dbVersion.RecLastUpdatedBy = regionRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.CityCode = city.CityCode;
            dbVersion.CityName = city.CityName;
            dbVersion.CityDescription = city.CityDescription;
            dbVersion.CountryId = city.CountryId;
            dbVersion.RegionId = city.RegionId;
            dbVersion.SubRegionId = city.SubRegionId;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long cityId)
        {
            // Assocoation with area check 
            if (areaRepository.IsCityAssociatedWithArea(cityId))
                throw new CaresException(Resources.GeographicalHierarchy.City.CityIsAssociatedWithAreaError);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityService(IRegionRepository regionRepository, ICountryRepository countryRepository, ICityRepository cityRepository,
            ISubRegionRepository subRegionRepository, IAreaRepository areaRepository)
        {
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.subRegionRepository = subRegionRepository;
            this.areaRepository = areaRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Cities
        /// </summary>
        public IEnumerable<City> LoadAll()
        {
            return cityRepository.GetAll();
        }

        /// <summary>
        /// Load City Base Data
        /// </summary>
        public CityBaseDataResponse LoadCityBaseData()
        {
            return new CityBaseDataResponse
            {
                Countries = countryRepository.GetAll(),
                Regions = regionRepository.GetAll(),
                SubRegions = subRegionRepository.GetAll()
            };
        }

        /// <summary>
        /// Search City
        /// </summary>
        public CitySearchRequestResponse SearchCity(CitySearchRequest request)
        {
            int rowCount;
            return new CitySearchRequestResponse
            {
                Cities = cityRepository.SearchCity(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete City by id
        /// </summary>
        public void DeleteCity(long cityId)
        {
            City dbversion = cityRepository.Find((int)cityId);
            ValidateBeforeDeletion(cityId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(Resources.GeographicalHierarchy.City.CityNotFoundInDatabase);
            }
            cityRepository.Delete(dbversion);
            cityRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update City
        /// </summary>
        public City SaveCity(City city)
        {
            City dbVersion = cityRepository.Find(city.CityId);

            //Code Duplication Check
            if (cityRepository.DoesCityCodeExists(city))
                throw new CaresException(Resources.GeographicalHierarchy.City.CityCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateCityPropertie(city, dbVersion);
                cityRepository.Update(dbVersion);
            }
            else
            {
                dbVersion=new City();
                SetCityProperties(city, dbVersion);
                cityRepository.Add(dbVersion);
            }
            regionRepository.SaveChanges();
            // To Load the proprties
            return cityRepository.LoadCityWithDetail(dbVersion.CityId);
        }
        #endregion
    }
}