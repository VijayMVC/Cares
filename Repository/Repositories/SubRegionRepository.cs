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
    /// Sub Region Repository
    /// </summary>
    public sealed class SubRegionRepository : BaseRepository<SubRegion>, ISubRegionRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SubRegionRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<SubRegion> DbSet
        {
            get
            {
                return db.SubRegions;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Sub Regions for User Domain Key
        /// </summary>
        public override IEnumerable<SubRegion> GetAll()
        {
            return DbSet.Where(subRegion => subRegion.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Find Sub Region By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubRegion Find(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion


   
    }
}
