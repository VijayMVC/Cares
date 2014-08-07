using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Microsoft.Owin.Security.Provider;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
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
        public CountryRegionsService(IRegionRepository _regionRepository)
        {
            this.regionRepository = _regionRepository;
        }
        #endregion
    }
}
