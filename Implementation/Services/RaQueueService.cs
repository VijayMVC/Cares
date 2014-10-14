using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// RA Queue Service
    /// </summary>
    public class RaQueueService : IRaQueueService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IRaStatusRepository raStatusRepository;
        private readonly IRentalAgreementRepository rentalAgreementRepository;
        #endregion

        #region Constructors
        public RaQueueService(IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            IPaymentTermRepository paymentTermRepository, IRaStatusRepository raStatusRepository, IRentalAgreementRepository rentalAgreementRepository)
        {
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.raStatusRepository = raStatusRepository;
            this.rentalAgreementRepository = rentalAgreementRepository;
        }
        #endregion

        #region Public

        /// <summary>
        /// Get RA Queue Base Data
        /// </summary>
        /// <returns></returns>
        public RaQueueBaseResponse GetBaseData()
        {
            return new RaQueueBaseResponse
            {
                Operations = operationRepository.GetSalesOperation(),
                OperationWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace(),
                PaymentTerms = paymentTermRepository.GetAll(),
                RaStatuses = raStatusRepository.GetAll(),
            };
        }



        /// <summary>
        /// Load RA Queue, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RaMainForRaQueueSearchResponse LoadRaQueues(RaQueueSearchRequest request)
        {
            return rentalAgreementRepository.GetRaMainsForRaQueue(request);
        }
        #endregion
    }
}
