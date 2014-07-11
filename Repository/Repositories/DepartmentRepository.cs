using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;
namespace Repository.Repositories
{
    public sealed class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DepartmentRepository(IUnityContainer container)
            : base(container)
        {
        }

        #endregion
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Department> DbSet
        {
            get
            {
                return  db.Departments;
            }
        }

        public IEnumerable<Department> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
