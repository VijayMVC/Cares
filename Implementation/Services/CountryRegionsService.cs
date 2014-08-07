using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// FleetPool Service
    /// </summary>
    public sealed class CountryRegionsService : ICountryRegionsService
    {
        #region Public
        public IEnumerable<Region> GetCoutryRegion(int id)
        {
            return regionRepository.GetRegions(id);
        }
        #endregion


        #region Private
        private readonly IRegionRepository regionRepository;
        #endregion

         #region Constructors
        public CountryRegionsService(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        #endregion
    }
}
