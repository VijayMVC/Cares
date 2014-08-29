using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    public sealed class WorkLocationRepository : BaseRepository<WorkLocation>, IWorkLocationRepository
    {
        #region privte
       
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkLocationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<WorkLocation> DbSet
        {
            get
            {
                return db.WorkLocations;
            }
        }

        #endregion
        #region
        /// <summary>
        /// Get all WorkLocations
        /// </summary>
        public override IEnumerable<WorkLocation> GetAll()
        {
            return DbSet.Where(workLocation => workLocation.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
