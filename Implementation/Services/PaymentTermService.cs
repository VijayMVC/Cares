using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
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
