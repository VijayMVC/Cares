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
    /// Employee Authorized Operations Workplace Repository
    /// </summary>
    public sealed class EmpAuthOperationsWorkplaceRepository : BaseRepository<EmpAuthOperationsWorkplace>, IEmpAuthOperationsWorkplaceRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpAuthOperationsWorkplaceRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpAuthOperationsWorkplace> DbSet
        {
            get
            {
                return db.EmpAuthOperationsWorkplaces;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Employee Job Progress for User Domain Key
        /// </summary>
        public override IEnumerable<EmpAuthOperationsWorkplace> GetAll()
        {
            return DbSet.Where(x => x.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
