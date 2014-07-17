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
            return new BusinessPartnerBaseDataResponse()
                   {
                       ResponseCompanies =  companyRepository.GetAll(),
                       ResponsePaymentTerms = paymentTermRepository.GetAll(),
                       ResponseBusinessLegalStatuses = businessLegalStatusRepository.GetAll(),
                       ResponseBPRatingTypes = bpRatingTypeRepository.GetAll(),
                       ResponseBusinessPartners = businessPartnerRepository.GetAll(),
                       ResponseDealingEmployees = employeeRepository.GetAll()
                   };

        }
        #endregion
    }
}
