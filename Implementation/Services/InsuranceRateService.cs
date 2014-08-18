using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Insurance Rate Service
    /// </summary>
    public class InsuranceRateService : IInsuranceRateService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IInsuranceRtMainRepository insuranceRtMainRepository;
        #endregion
        #region Constructors

        public InsuranceRateService(IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository, IInsuranceRtMainRepository insuranceRtMainRepository)
        {
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.insuranceRtMainRepository = insuranceRtMainRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Tariff Rate Base Data
        /// </summary>
        /// <returns></returns>
        public InsuranceRateBaseResponse GetBaseData()
        {
            return new InsuranceRateBaseResponse
                   {
                       Operations = operationRepository.GetAll(),
                       TariffTypes = tariffTypeRepository.GetAll(),
                   };
        }

        public InsuranceRateSearchResponse LoadInsuranceRates(InsuranceRateSearchRequest request)
        {
            return insuranceRtMainRepository.GetInsuranceRates(request);
        }

        #endregion
    }
}
