using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Additional Driver Service
    /// </summary>
    public class AdditionalDriverService : IAdditionalDriverService
    {
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IAdditionalDriverChargeRepository additionalDriverChargeRepository;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        public AdditionalDriverService(ICompanyRepository companyRepository,IAdditionalDriverChargeRepository additionalDriverChargeRepository,
            IDepartmentRepository departmentRepository, IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository)
        {
            this.companyRepository = companyRepository;
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.departmentRepository = departmentRepository;
            this.additionalDriverChargeRepository = additionalDriverChargeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load company Base data
        /// </summary>
        public AdditionalDriverBaseResponse GetBaseData()
        {
            return new AdditionalDriverBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                TariffTypes = tariffTypeRepository.GetAll(),

            };
        }

        /// <summary>
        /// Get Additional Driver Charge Detail
        /// </summary>
        /// <param name="additionalDriverChargeId"></param>
        /// <returns></returns>
        public IEnumerable<AdditionalDriverCharge> GetAdditionalDriverChargeDetail(long additionalDriverChargeId)
        {
            return additionalDriverChargeRepository.GetRevisions(additionalDriverChargeId);
        }

        /// <summary>
        /// Load Additional Driver Charge Based on search criteria
        /// </summary>
        /// <returns></returns>
        public AdditionalDriverChargeSearchResponse LoadAll(AdditionalDriverChargeSearchRequest request)
        {
            return additionalDriverChargeRepository.GetAdditionalDriverCharges(request);
        }
        #endregion
    }
}
