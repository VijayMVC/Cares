using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Payment Term Service
    /// </summary>
    public class PaymentTermService : IPaymentTermService
    {
        #region Private
        private readonly IPaymentTermRepository paymentTermRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paymentTermRepository"></param>
        public PaymentTermService(IPaymentTermRepository paymentTermRepository)
        {
            this.paymentTermRepository = paymentTermRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Load All
        /// </summary>
        /// <returns></returns>
        public IQueryable<PaymentTerm> LoadAll()
        {
            return paymentTermRepository.GetAll();
        }
        #endregion
    }
}
