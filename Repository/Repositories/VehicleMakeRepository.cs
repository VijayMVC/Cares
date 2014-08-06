using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Vehicle Make Repository
    /// </summary>
    public sealed class VehicleMakeRepository : BaseRepository<VehicleMake>, IVehicleMakeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleMakeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleMake> DbSet
        {
            get
            {
                return db.VehicleMakes;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Makes for User Domain Key
        /// </summary>
        public override IQueryable<VehicleMake> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }
        #endregion
    }
}
