using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Standard Discount Repository
    /// </summary>
    public sealed class StandardDiscountRepository : BaseRepository<StandardDiscount>, IStandardDiscountRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardDiscountRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardDiscount> DbSet
        {
            get
            {
                return db.StandardDiscounts;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Association check of Standard Discount and vehicle make
        /// </summary>
        public bool IsStandardDiscountAssociatedWithVehicleMake(long vehicleMakeId)
        {
            return DbSet.Count(standardDicount => standardDicount.VehicleMakeId == vehicleMakeId) > 0;
        }

        #endregion
    }
}
