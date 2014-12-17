using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    public class DomainLicenseDetailsRepository : BaseRepository<DomainLicenseDetail>, IDomainLicenseDetailsRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DomainLicenseDetailsRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DomainLicenseDetail> DbSet
        {
            get
            {
                return db.DomainLicenseDetails;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Domain License Detail By DomainKey
        /// </summary>
        public DomainLicenseDetail GetDomainLicenseDetailByDomainKey(double domainKey)
        {

            return DbSet.FirstOrDefault(domainLicenseDetail => domainLicenseDetail.UserDomainKey == domainKey);
        }
        #endregion
    }
}
