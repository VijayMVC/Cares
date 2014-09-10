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
    /// License Type Repository
    /// </summary>
    public sealed class LicenseTypeRepository : BaseRepository<LicenseType>, ILicenseTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<LicenseType> DbSet
        {
            get
            {
                return db.LicenseTypes;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get License Types for User Domain Key
        /// </summary>
        public override IEnumerable<LicenseType> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
