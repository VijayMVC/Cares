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

        private readonly IOccupationTypeRepository occupationTypeRepository;
        private readonly IBusinessPartnerCompanyRepository businessPartnerCompanyRepository;
        private readonly ICountryRepository passportCountryRepository;

        #endregion
        #region Constructor

        public BusinessPartnerBaseDataService(ICompanyRepository companyRepository
            , IPaymentTermRepository paymentTermRepository
            , IBusinessLegalStatusRepository businessLegalStatusRepository
            , IBpRatingTypeRepository bpRatingTypeRepository
            , IBusinessPartnerRepository businessPartnerRepository
            ,IEmployeeRepository employeeRepository
            , IOccupationTypeRepository occupationTypeRepository
            , IBusinessPartnerCompanyRepository businessPartnerCompanyRepository
            , ICountryRepository passportCountryRepository)
        {
            this.companyRepository = companyRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.businessLegalStatusRepository = businessLegalStatusRepository;
            this.bpRatingTypeRepository = bpRatingTypeRepository;
            this.businessPartnerRepository = businessPartnerRepository;
            this.employeeRepository = employeeRepository;
            this.occupationTypeRepository = occupationTypeRepository;
            this.businessPartnerCompanyRepository = businessPartnerCompanyRepository;
            this.passportCountryRepository = passportCountryRepository;
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
            response.ResponseOccupationTypes = occupationTypeRepository.GetAll();
            response.ResponseBusinessPartnerCompanies = businessPartnerCompanyRepository.GetAll();
            response.ResponsePassportCountries = passportCountryRepository.GetAll();

            return response;
        }
        #endregion
    }
}
