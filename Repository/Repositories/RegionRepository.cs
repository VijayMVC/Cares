using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;
using System.Collections.Generic;

namespace Repository.Repositories
{
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
        public override IQueryable<Region> GetAll()
        {
            return DbSet.Where(region => region.UserDomainKey == UserDomainKey);
        }


        public IEnumerable<Region> GetRegions(int id)
        {
            return DbSet.Where(region => region.CountryId == id);
        }

        #endregion

        }
}
