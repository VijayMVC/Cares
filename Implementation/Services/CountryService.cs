using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Country Service
    /// </summary>
    public class CountryService : ICountryService
    {
        #region Private
        private readonly ICountryRepository countryRepository;
        #endregion
        #region Constructor
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Load all countries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Country> LoadAll()
        {
            return countryRepository.GetAll();
        }
        #endregion
    }
}
