
using System.Collections.Generic;
using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
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
        public IQueryable<Country> LoadAll()
        {
            return countryRepository.GetAll();
        }
        #endregion
    }
}
