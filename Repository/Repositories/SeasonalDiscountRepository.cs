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
        /// <param name="seasonalDiscountMainId"></param>
        /// <returns></returns>
        public IEnumerable<SeasonalDiscount> GetSeasonalDiscountsBySeasonalDiscountMainId(long seasonalDiscountMainId)
        {
            return
                DbSet.Where(
                    addChrg =>
                        addChrg.ChildSeasonalDiscountId == null &&
                        addChrg.SeasonalDiscountMainId == seasonalDiscountMainId).ToList();

        }


        #endregion
    }
}
