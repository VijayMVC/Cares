using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.CommonTypes;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
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
