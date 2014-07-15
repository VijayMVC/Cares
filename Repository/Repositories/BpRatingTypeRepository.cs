using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public sealed class BpRatingTypeRepository : BaseRepository<BpRatingType>, IBpRatingTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpRatingTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BpRatingType> DbSet
        {
            get
            {
                return db.BpRatingTypes;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IQueryable<BpRatingType> GetAll()
        {
            return DbSet.Where(bpRatingType => bpRatingType.UserDomainKey == UserDomaingKey);
        }

        #endregion
    }
}
