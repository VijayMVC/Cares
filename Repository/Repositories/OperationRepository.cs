using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Operation Repository
    /// </summary>
    public sealed class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OperationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Operation> DbSet
        {
            get
            {
                return db.Operations;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Organization Groups for User Domain Key
        /// </summary>
        public override IQueryable<Operation> GetAll()
        {
            return DbSet.Where(operation => operation.UserDomainKey == UserDomainKey && operation.Department.DepartmentType == DepartmentTypes.Sales);
        }

        public IQueryable<Operation> GetSalesOperation()
        {
            return DbSet.Where(operation => operation.Department.DepartmentType == DepartmentTypes.Sales);
        }

        #endregion
    }
}
