using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nrt Vehicle Repository
    /// </summary>
    public class NrtVehicleRepository : BaseRepository<NrtVehicle>, INrtVehicleRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtVehicleRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtVehicle> DbSet
        {
            get
            {
                return db.NrtVehicles;
            }
        }
        #endregion

       
    }
}
