using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Company Repository
    /// </summary>
    public sealed class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Company> DbSet
        {
            get
            {
                return db.Companies;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Companies for User Domain Key
        /// </summary>
        public override IQueryable<Company> GetAll()
        {
            return DbSet.Where(company => company.UserDomainKey == UserDomainKey && (company.ParentCompanyId==0 ||company.ParentCompanyId==null));
        }

        #endregion
    }
}
