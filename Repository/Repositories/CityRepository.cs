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
        public City Find(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Get Cities By Country
        /// </summary>
        public IQueryable<City> GetCitiesByCountry(int countryId)
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey && city.CountryId == countryId);
        }


        /// <summary>
        /// Check if region is asssociated with any city
        /// </summary>
        public bool IsRegionAssociatedWithCity(long regionId)
        {
            return DbSet.Count(city => city.UserDomainKey == UserDomainKey && city.RegionId == regionId)>0;
        }
        #endregion
    }
}
