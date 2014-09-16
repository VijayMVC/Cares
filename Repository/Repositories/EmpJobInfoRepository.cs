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
    ///IEmployee Job Info Repository
    /// </summary>
    public sealed class EmpJobInfoRepository : BaseRepository<EmpJobInfo>, IEmpJobInfoRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpJobInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpJobInfo> DbSet
        {
            get
            {
                return db.EmpJobInfos;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Emp Job Info for User Domain Key
        /// </summary>
        public override IEnumerable<EmpJobInfo> GetAll()
        {
            return DbSet.Where(empJobInfo => empJobInfo.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
