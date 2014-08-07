using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Department Repository
    /// </summary>
    public sealed class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DepartmentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Department> DbSet
        {
            get
            {
                return db.Departments;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Departments for User Domain Key
        /// </summary>
        public override IQueryable<Department> GetAll()
        {
            return DbSet.Where(department => department.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
