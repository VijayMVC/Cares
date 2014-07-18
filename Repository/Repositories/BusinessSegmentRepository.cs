using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Business Segment Repository
    /// </summary>
    public sealed class BusinessSegmentRepository : BaseRepository<BusinessSegment>, IBusinessSegmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessSegmentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessSegment> DbSet
        {
            get
            {
                return db.BusinessSegments;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Business Segments for User Domain Key
        /// </summary>
        public override IQueryable<BusinessSegment> GetAll()
        {
            return DbSet.Where(businessSegment => businessSegment.UserDomainKey == UserDomainKey);
        }

        #endregion

    }
}
