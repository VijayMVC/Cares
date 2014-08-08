using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Address Base Service
    /// </summary>
    public class AddressBaseDataService : IAddressBaseDataService
    {
        #region Private
        private readonly ICountryRepository countryRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ISubRegionRepository subRegionRepository;
        private readonly ICityRepository cityRepository;
        private readonly IAreaRepository areaRepository;
        #endregion

        #region Constructor
        public AddressBaseDataService(ICountryRepository countryRepository
            , IRegionRepository regionRepository
            , ISubRegionRepository subRegionRepository
            , ICityRepository cityRepository
            , IAreaRepository areaRepository)
        {
            this.countryRepository = countryRepository;
            this.regionRepository = regionRepository;
            this.subRegionRepository = subRegionRepository;
            this.cityRepository = cityRepository;
            this.areaRepository = areaRepository;
        }
        #endregion

        #region Public Methods
        public AddressBaseDataResponse LoadDataByCountry(int id)
        {
            AddressBaseDataResponse response = new AddressBaseDataResponse();
            response.ResponseCountry = countryRepository.Find(id);
            response.ResponseRegions = regionRepository.GetRegionsByCountry(id);
            response.ResponseCities = cityRepository.GetCitiesByCountry(id);
            response.ResponseSubRegions = subRegionRepository.GetAll();
            response.ResponseAreas = areaRepository.GetAll();
            return response;
        }
        #endregion
    }
}
