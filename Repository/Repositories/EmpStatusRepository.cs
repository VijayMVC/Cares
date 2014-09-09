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
    /// Employee Status Repository 
    /// </summary>
    public sealed class EmpStatusRepository : BaseRepository<EmpStatus>, IEmpStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpStatus> DbSet
        {
            get
            {
                return db.EmpStatuses;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get Employee Status for User Domain Key
        /// </summary>
        public override IEnumerable<EmpStatus> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
