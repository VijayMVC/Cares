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
        public override IEnumerable <Company> GetAll()
        {
            return DbSet.Where(company => company.UserDomainKey == UserDomainKey && (company.ParentCompanyId==0 ||company.ParentCompanyId==null)).ToList();
        }

        #endregion
    }
}
