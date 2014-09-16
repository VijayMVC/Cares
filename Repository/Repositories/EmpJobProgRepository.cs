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
    /// Employee Job Progress Repository 
    /// </summary>
    public sealed class EmpJobProgRepository : BaseRepository<EmpJobProg>, IEmpJobProgRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpJobProgRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpJobProg> DbSet
        {
            get
            {
                return db.EmpJobProgs;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Employee Job Progress for User Domain Key
        /// </summary>
        public override IEnumerable<EmpJobProg> GetAll()
        {
            return DbSet.Where(empJobProg => empJobProg.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
