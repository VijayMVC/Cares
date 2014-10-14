using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
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
        #endregion

        #region Constructors
        public RaQueueService(IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            IPaymentTermRepository paymentTermRepository, IRaStatusRepository raStatusRepository)
        {
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.raStatusRepository = raStatusRepository;
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
        public RaQueueBaseResponse LoadRaQueues(RaQueueSearchRequest request)
        {
            //return tariffTypeRepository.GettariffTypes(tariffTypeRequest);
            return null;
        }
        #endregion
    }
}
