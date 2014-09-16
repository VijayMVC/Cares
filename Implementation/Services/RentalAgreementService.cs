using System;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Rental Agreement ervice
    /// </summary>
    public class RentalAgreementService : IRentalAgreementService
    {
        #region Private
        
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementService(IPaymentTermRepository paymentTermRepository, IOperationRepository operationRepository, 
            IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
        {
            if (paymentTermRepository == null)
            {
                throw new ArgumentNullException("paymentTermRepository");
            }

            if (operationRepository == null)
            {
                throw new ArgumentNullException("operationRepository");
            }
            if (operationsWorkPlaceRepository == null)
            {
                throw new ArgumentNullException("operationsWorkPlaceRepository");
            }

            this.paymentTermRepository = paymentTermRepository;
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Base Data
        /// </summary>
        public RentalAgreementBaseDataResponse GetBaseData()
        {
            return new RentalAgreementBaseDataResponse
            {
                PaymentTerms = paymentTermRepository.GetAll(),
                Operations = operationRepository.GetSalesOperation(),
                OperationsWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace()
            };
        }

        #endregion
    }
}
