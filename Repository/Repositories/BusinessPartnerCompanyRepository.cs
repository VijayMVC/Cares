using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Business Partner Company Repository
    /// </summary>
    public sealed class BusinessPartnerCompanyRepository : BaseRepository<BusinessPartnerCompany>, IBusinessPartnerCompanyRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerCompanyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerCompany> DbSet
        {
            get
            {
                return db.BusinessPartnerCompanies;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Get All Business Partner Companies for User Domain Key
        /// </summary>
        public override IQueryable<BusinessPartnerCompany> GetAll()
        {
            return DbSet.Where(businessPartnerCompany => businessPartnerCompany.UserDomainKey == UserDomainKey);
        }

        #endregion





       
    }
}
