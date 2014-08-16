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
        public override IEnumerable<BusinessSegment> GetAll()
        {
            return DbSet.Where(businessSegment => businessSegment.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion

    }
}
