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
    /// Payment Mode Repository
    /// </summary>
    public sealed class PaymentModeRepository : BaseRepository<PaymentMode>, IPaymentModeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentModeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<PaymentMode> DbSet
        {
            get
            {
                return db.PaymentModes;
            }
        }
        #endregion
       
        #region Public
        
        /// <summary>
        /// Get All Payment Modes for User Domain Key
        /// </summary>
        public override IEnumerable<PaymentMode> GetAll()
        {
            return DbSet.Where(paymentMode => paymentMode.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
