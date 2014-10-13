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
    /// Seasonal Discount Repository
    /// </summary>
    public class SeasonalDiscountRepository : BaseRepository<SeasonalDiscount>, ISeasonalDiscountRepository
    {

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<SeasonalDiscount> DbSet
        {
            get
            {
                return db.SeasonalDiscounts;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Seasonal Discount for User Domain Key
        /// </summary>
        public override IEnumerable<SeasonalDiscount> GetAll()
        {
            return DbSet.Where(seasonalDiscount => seasonalDiscount.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// Get Seasonal Discounts By Seasonal Discount Main Id
        /// </summary>
        public IEnumerable<SeasonalDiscount> GetSeasonalDiscountsBySeasonalDiscountMainId(long seasonalDiscountMainId)
        {
            return
                DbSet.Where(
                    addChrg =>
                        addChrg.ChildSeasonalDiscountId == null &&
                        addChrg.SeasonalDiscountMainId == seasonalDiscountMainId).ToList();

        }

        /// <summary>
        /// Association check of Seasonal Discount and Vehicle Make
        /// </summary>
        public bool IsSeasonalDiscountAssociatedWithVehicleMake(long vehicleMakeId)
        {
            return DbSet.Count(sessionlaDiscount => sessionlaDiscount.VehicleMakeId == vehicleMakeId) > 0;
        }

        /// <summary>
        /// Association check of Seasonal Discount and Vehicle Category
        /// </summary>
        public bool IsSeasonalDiscountAssociatedWithVehicleCategory(long vehicleCategoryId)
        {
            return DbSet.Count(sessionlaDiscount => sessionlaDiscount.VehicleCategoryId == vehicleCategoryId) > 0;

        }

        /// <summary>
        /// Association check of Seasonal Discount and Vehicle Model
        /// </summary>
        public bool IsSeasonalDiscountAssociatedWithVehicleModel(long vehicleModelId)
        {
            return DbSet.Count(sessionlaDiscount => sessionlaDiscount.VehicleModelId == vehicleModelId) > 0;
            
        }

        #endregion
    }
}
