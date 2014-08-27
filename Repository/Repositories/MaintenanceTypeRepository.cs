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
    /// Maintenance Type Repository
    /// </summary>
    public sealed class MaintenanceTypeRepository : BaseRepository<MaintenanceType>, IMaintenanceTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Maintenance Type Repository Constructor
        /// </summary>
        public MaintenanceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MaintenanceType> DbSet
        {
            get
            {
                return db.MaintenanceTypes;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Get All Maintenance Type for User Domain Key
        /// </summary>
        public override IEnumerable<MaintenanceType> GetAll()
        {
            return DbSet.Where(mt => mt.UserDomainKey == UserDomainKey).ToList();
        }


        #endregion
    }
}
