using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nrt Charge Repository
    /// </summary>
    public class NrtChargeRepository : BaseRepository<NrtCharge>, INrtChargeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtChargeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtCharge> DbSet
        {
            get
            {
                return db.NrtCharges;
            }
        }
        #endregion
    }
}
