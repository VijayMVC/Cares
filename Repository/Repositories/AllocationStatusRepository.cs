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
    /// Allocation Status Repository
    /// </summary>
    public sealed class AllocationStatusRepository : BaseRepository<AllocationStatus>, IAlloactionStatusRepository 
    {
        #region Constructor
        /// <summary>
        /// Allocation Status Repository Constructor
        /// </summary>
        public AllocationStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AllocationStatus> DbSet
        {
            get
            {
                return db.AllocationStatuses;
            }
        }

        #endregion
        
        #region Public
        
        /// <summary>
        /// Get All Allocation Status for User Domain Key
        /// </summary>
        public override IEnumerable<AllocationStatus> GetAll()
        {
            return DbSet.ToList();
        }


        #endregion
    }
}
