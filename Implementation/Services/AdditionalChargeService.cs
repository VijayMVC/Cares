using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Additional Charge Service
    /// </summary>
    public class AdditionalChargeService : IAdditionalChargeService
    {
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IAdditionalChargeRepository additionalChargeRepository;
        private readonly IAdditionalChargeTypeRepository additionalChargeTypeRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        public AdditionalChargeService(IAdditionalChargeRepository additionalChargeRepository, IAdditionalChargeTypeRepository additionalChargeTypeRepository,
         IHireGroupDetailRepository hireGroupDetailRepository)
        {
            this.additionalChargeRepository = additionalChargeRepository;
            this.additionalChargeTypeRepository = additionalChargeTypeRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Additional Charge Base data
        /// </summary>
        public AdditionalChargeBaseResponse GetBaseData()
        {
            return new AdditionalChargeBaseResponse
            {
                HireGroupDetails = hireGroupDetailRepository.GetAll(),
            };
        }

        /// <summary>
        /// Load Additional Charge Based on search criteria
        /// </summary>
        /// <returns></returns>
        public AdditionalChargeSearchResponse LoadAll(AdditionalChargeSearchRequest request)
        {
            return additionalChargeTypeRepository.GetAdditionalCharges(request);
        }

        #endregion
    }
}
