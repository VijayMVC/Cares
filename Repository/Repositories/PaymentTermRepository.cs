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
    /// Payment Term Repository
    /// </summary>
    public sealed class PaymentTermRepository : BaseRepository<PaymentTerm>, IPaymentTermRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentTermRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<PaymentTerm> DbSet
        {
            get
            {
                return db.PaymentTerms;
            }
        }
        #endregion
       
        #region Public
        /// <summary>
        /// Get All Organization Groups for User Domain Key
        /// </summary>
        public override IEnumerable<PaymentTerm> GetAll()
        {
            return DbSet.ToList();
        }
        #endregion
    }
}
