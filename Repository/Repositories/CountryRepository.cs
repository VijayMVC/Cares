
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Country Repository
    /// </summary>
    public sealed class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CountryRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Country> DbSet
        {
            get
            {
                return db.Countries;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Business Segments for User Domain Key
        /// </summary>
        public override IQueryable<Country> GetAll()
        {
            return DbSet.Where(country => country.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
