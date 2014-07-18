using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// Business Partner Base Service
    /// </summary>
    public class BusinessPartnerBaseDataService : IBusinessPartnerBaseDataService
    {
        #region Private
        private readonly ICompanyRepository companyRepository;
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IBusinessLegalStatusRepository businessLegalStatusRepository;
        private readonly IBpRatingTypeRepository bpRatingTypeRepository;
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        private readonly IEmployeeRepository employeeRepository;
        #endregion
        #region Constructor

        public BusinessPartnerBaseDataService(ICompanyRepository companyRepository
            , IPaymentTermRepository paymentTermRepository
            , IBusinessLegalStatusRepository businessLegalStatusRepository
            , IBpRatingTypeRepository bpRatingTypeRepository
            , IBusinessPartnerRepository businessPartnerRepository
            ,IEmployeeRepository employeeRepository)
        {
            this.companyRepository = companyRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.businessLegalStatusRepository = businessLegalStatusRepository;
            this.bpRatingTypeRepository = bpRatingTypeRepository;
            this.businessPartnerRepository = businessPartnerRepository;
            this.employeeRepository = employeeRepository;
        }
        #endregion
        #region Public
        public BusinessPartnerBaseDataResponse LoadAll()
        {
            BusinessPartnerBaseDataResponse response = new BusinessPartnerBaseDataResponse();

            response.ResponseCompanies = companyRepository.GetAll();
            response.ResponsePaymentTerms = paymentTermRepository.GetAll();
            response.ResponseBusinessLegalStatuses = businessLegalStatusRepository.GetAll();
            response.ResponseBPRatingTypes = bpRatingTypeRepository.GetAll();
            response.ResponseBusinessPartners = businessPartnerRepository.GetAll();
            response.ResponseDealingEmployees = employeeRepository.GetAll();

            return response;
        }
        #endregion
    }
}
