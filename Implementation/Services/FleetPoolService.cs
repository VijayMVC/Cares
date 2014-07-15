using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// FleetPool Service
    /// </summary>
    public sealed class FleetPoolService:IFleetPoolService
    {
        #region Public
        /// <summary>
        /// Load All Fleet Pools
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IQueryable<FleetPool> LoadAll(FleetPoolSearchRequest searchRequest)
        {
            return fleetPoolRepository.GetAll(searchRequest);
        } 
        #endregion

        #region Constructor
        public FleetPoolService(IFleetPoolRepository iFleetPoolRepositoryService)
        {
            fleetPoolRepository = iFleetPoolRepositoryService;
        }
        #endregion

        #region Private
        private readonly IFleetPoolRepository fleetPoolRepository;
        #endregion
    }
}
