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
    /// Designation Repository
    /// </summary>
    public sealed class DesignationRepository : BaseRepository<Designation>, IDesignationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Designation> DbSet
        {
            get
            {
                return db.Designations;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get Designation for User Domain Key
        /// </summary>
        public override IEnumerable<Designation> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
