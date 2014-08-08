using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Area Repository
    /// </summary>
    public sealed class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Area> DbSet
        {
            get
            {
                return db.Areas;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Areas for User Domain Key
        /// </summary>
        public override IQueryable<Area> GetAll()
        {
            return DbSet.Where(area => area.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Find Area By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Area Find(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion


   
    }
}
