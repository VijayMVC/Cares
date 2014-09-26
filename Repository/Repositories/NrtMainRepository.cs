using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nr tMain Repository 
    /// </summary>
    public class NrtMainRepository : BaseRepository<NrtMain>, INrtMainRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtMain> DbSet
        {
            get
            {
                return db.NrtMain;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Associaton check with nrt type before deletion
        /// </summary>
        public bool IsNrtMainAssociatedWithNrtType(long nrtTypeId)
        {
            return DbSet.Count(nrtmain => nrtmain.NrtTypeId == nrtTypeId) > 0;
        }
        #endregion
    }
}
