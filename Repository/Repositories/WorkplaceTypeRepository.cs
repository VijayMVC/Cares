using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
      /// <summary>
      /// Workplace Type Repository
      /// </summary>
    public sealed class WorkplaceTypeRepository : BaseRepository<WorkPlaceType>, IWorkplaceTypeRepository
    {
       #region Private
      
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkplaceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<WorkPlaceType> DbSet
        {
            get
            {
                return db.WorkPlaceType;
            }
        }

        #endregion
       #region public

        /// <summary>
        /// Get all WorkPlace Types
        /// </summary>
        public override IEnumerable<WorkPlaceType> GetAll()
        {
            return DbSet.Where(workPlaceType => workPlaceType.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
