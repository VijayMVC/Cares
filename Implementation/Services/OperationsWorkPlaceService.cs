using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Operations Work Place service
    /// </summary>
    public class OperationsWorkPlaceService : IOperationsWorkPlaceService
    {

        #region Private

        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructors
        /// </summary>
        public OperationsWorkPlaceService(IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
        {
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Operations Work Place By Workplace Id
        /// </summary>
        public OperationWorkplaceSearchByIdResponse GetOperationsWorkPlaceByWorkplaceId(long workPlaceId)
        {
            return new OperationWorkplaceSearchByIdResponse
            {
                OperationWorkPlaces = operationsWorkPlaceRepository.GetWorkPlaceOperationByWorkPlaceId(workPlaceId)
            };
        }
        #endregion
    }
}
