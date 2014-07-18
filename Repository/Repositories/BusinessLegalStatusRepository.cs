using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public sealed class BusinessLegalStatusRepository : BaseRepository<BusinessLegalStatus>, IBusinessLegalStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessLegalStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessLegalStatus> DbSet
        {
            get
            {
                return db.BusinessLegalStatuses;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Business Segments for User Domain Key
        /// </summary>
        public override IQueryable<BusinessLegalStatus> GetAll()
        {
            return DbSet.Where(businessLegalStatus => businessLegalStatus.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
