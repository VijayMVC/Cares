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
    /// Region Repository
    /// </summary>
    public sealed class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Region> DbSet
        {
            get
            {
                return db.Regions;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IEnumerable<Region> GetAll()
        {
            return DbSet.Where(region => region.UserDomainKey == UserDomainKey).ToList();
        }
        public IEnumerable<Region> GetRegions(int id)
        {
            return DbSet.Where(region => region.CountryId == id);
        }
        /// <summary>
        /// Get Regions by Country Id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public IEnumerable<Region> GetRegionsByCountry(int countryId)
        {
            return DbSet.Where(region => region.CountryId == countryId);
        }
        public Region Find(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
