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
    /// Job Type Repository
    /// </summary>
    public sealed class JobTypeRepository : BaseRepository<JobType>, IJobTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public JobTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<JobType> DbSet
        {
            get
            {
                return db.JobTypes;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get Job Types for User Domain Key
        /// </summary>
        public override IEnumerable<JobType> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
