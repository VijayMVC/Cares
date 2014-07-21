using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Hire Group Repository
    /// </summary>
    public sealed class HireGroupRepository : BaseRepository<HireGroup>, IHireGroupRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroup> DbSet
        {
            get
            {
                return db.HireGroups;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Hire Groups 
        /// </summary>
        public override IQueryable<HireGroup> GetAll()
        {
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && hireGroup.ParentHireGroupId == 0);
        }
        #endregion
    }
}
