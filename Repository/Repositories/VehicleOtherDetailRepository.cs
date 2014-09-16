using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    ///Vehicle Other Detail Repository
    /// </summary>
    public class VehicleOtherDetailRepository : BaseRepository<VehicleOtherDetail>, IVehicleOtherDetailRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleOtherDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleOtherDetail> DbSet
        {
            get
            {
                return db.VehicleOtherDetails;
            }
        }
        #endregion
    }
}
