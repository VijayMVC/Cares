using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Nrt Queue Service
    /// </summary>
    public class NrtQueueService : INrtQueueService
    {
        #region Private
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly IRaStatusRepository raStatusRepository;
        private readonly INrtTypeRepository nrtTypeRepository;
        private readonly INrtMainRepository nrtMainRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="nrtTypeRepository"></param>
        /// <param name="operationsWorkPlaceRepository"></param>
        /// <param name="raStatusRepository"></param>
        public NrtQueueService(INrtTypeRepository nrtTypeRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
          IRaStatusRepository raStatusRepository, INrtMainRepository nrtMainRepository)
        {
            this.nrtTypeRepository = nrtTypeRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.raStatusRepository = raStatusRepository;
            this.nrtMainRepository = nrtMainRepository;
        }
        #endregion

        #region Public

        /// <summary>
        /// Get NRT Queue Base Data
        /// </summary>
        /// <returns></returns>
        public NrtQueueBaseResponse GetBaseData()
        {
            return new NrtQueueBaseResponse
            {
                NrtTypes = nrtTypeRepository.GetAll(),
                OperationWorkPlaces = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace(),
                RaStatuses = raStatusRepository.GetAll(),
            };
        }



        /// <summary>
        /// Load NRT Queue, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NrtQueueSearchResponse LoadNrtQueues(NrtQueueSearchRequest request)
        {
            return nrtMainRepository.GetNrtMainsForNrtQueue(request);
        }
        #endregion
    }
}
