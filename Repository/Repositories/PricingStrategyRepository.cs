using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Pricing Strategy Repository
    /// </summary>
    public sealed class PricingStrategyRepository : BaseRepository<PricingStrategy>, IPricingStrategyRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PricingStrategyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<PricingStrategy> DbSet
        {
            get
            {
                return db.PricingStrategies;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IQueryable<PricingStrategy> GetAll()
        {
            return DbSet.Where(pricingStrategy => pricingStrategy.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
