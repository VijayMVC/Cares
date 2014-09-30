using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Credit Limit Repository
    /// </summary>
    public sealed class CreditLimitRepository : BaseRepository<CreditLimit>, ICreditLimitRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CreditLimitRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<CreditLimit> DbSet
        {
            get
            {
                return db.CreditLimits;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Associatin check of cradit limit with rating type
        /// </summary>
        public bool IsRatingTypeAssociatedWithCreditLimit(long ratingTypeId)
        {
            return DbSet.Count(creidtlimit => creidtlimit.BpRatingTypeId == ratingTypeId) > 0;
        }
        #endregion
    }
}
