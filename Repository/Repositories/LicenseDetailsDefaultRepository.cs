using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public class LicenseDetailsDefaultRepository : BaseRepository<LicenseDetailsDefault>, ILicenseDetailsDefaultRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseDetailsDefaultRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<LicenseDetailsDefault> DbSet
        {
            get
            {
                return db.LicenseDetailsDefault;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get License Details Default by license TypeId
        /// </summary>
        public LicenseDetailsDefault GetLicenseDetailsDefaultByTypeId(long licenseTypeId)
        {
            return DbSet.FirstOrDefault(licenseDetailsDefault => licenseDetailsDefault.LicenseTypeId == licenseTypeId);
        }
        #endregion
    }
}
