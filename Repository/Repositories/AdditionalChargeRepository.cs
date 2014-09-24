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
    /// Additional Charge Repository
    /// </summary>
    public class AdditionalChargeRepository : BaseRepository<AdditionalCharge>, IAdditionalChargeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AdditionalCharge> DbSet
        {
            get
            {
                return db.AdditionalCharges;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Additional Charge for User Domain Key
        /// </summary>
        public override IEnumerable<AdditionalCharge> GetAll()
        {
            return DbSet.Where(addChrg => addChrg.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
