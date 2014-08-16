using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// City Repository
    /// </summary>
    public sealed class CityRepository : BaseRepository<City>, ICityRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<City> DbSet
        {
            get
            {
                return db.Cities;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Cities for User Domain Key
        /// </summary>
        public override IEnumerable<City> GetAll()
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Find City By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City Find(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Get Cities By Country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public IQueryable<City> GetCitiesByCountry(int countryId)
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey && city.CountryId == countryId);
        }
        #endregion
    }
}
