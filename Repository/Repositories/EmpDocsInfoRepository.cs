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
    /// Employee Docs Info Repository
    /// </summary>
    public sealed class EmpDocsInfoRepository : BaseRepository<EmpDocsInfo>, IEmpDocsInfoRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpDocsInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpDocsInfo> DbSet
        {
            get
            {
                return db.EmpDocsInfos;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Employee Docs Info for User Domain Key
        /// </summary>
        public override IEnumerable<EmpDocsInfo> GetAll()
        {
            return DbSet.Where(empDocInfo => empDocInfo.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
