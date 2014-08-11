using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Partner Base Service
    /// </summary>
    public class BusinessPartnerBaseDataService : IBusinessPartnerBaseDataService
    {
        #region Private
        // For Business Partner Main
        private readonly ICompanyRepository companyRepository;
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IBusinessLegalStatusRepository businessLegalStatusRepository;
        private readonly IBpRatingTypeRepository bpRatingTypeRepository;
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        private readonly IEmployeeRepository employeeRepository;
        // For Individual Tab
        private readonly IOccupationTypeRepository occupationTypeRepository;
        private readonly IBusinessPartnerCompanyRepository businessPartnerCompanyRepository;
        private readonly ICountryRepository countryRepository;
        // For Company
        private readonly IBusinessSegmentRepository businessSegmentRepository;
        // For Business Patner type
        private readonly IBusinessPartnerSubTypeRepository businessPartnerSubTypeRepository;
        // For Phone tab
        private readonly IPhoneTypeRepository phoneTypeRepository;
        // For Address tab
        private readonly IAddressTypeRepository addressTypeRepository;
        // For Marketing Channel tab
        private readonly IMarketingChannelRepository marketingChannelRepository;
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
            , ICountryRepository passportCountryRepository
            , IBusinessSegmentRepository businessSegmentRepository
            ,IBusinessPartnerSubTypeRepository businessPartnerSubTypeRepository
            ,IPhoneTypeRepository phoneTypeRepository
            ,IAddressTypeRepository addressTypeRepository
            ,IMarketingChannelRepository marketingChannelRepository)
        {
            this.companyRepository = companyRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.businessLegalStatusRepository = businessLegalStatusRepository;
            this.bpRatingTypeRepository = bpRatingTypeRepository;
            this.businessPartnerRepository = businessPartnerRepository;
            this.employeeRepository = employeeRepository;
            this.occupationTypeRepository = occupationTypeRepository;
            this.businessPartnerCompanyRepository = businessPartnerCompanyRepository;
            this.countryRepository = passportCountryRepository;
            this.businessSegmentRepository = businessSegmentRepository;
            this.businessPartnerSubTypeRepository = businessPartnerSubTypeRepository;
            this.phoneTypeRepository = phoneTypeRepository;
            this.addressTypeRepository = addressTypeRepository;
            this.marketingChannelRepository = marketingChannelRepository;
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
            response.ResponseCountries = countryRepository.GetAll();
            response.ResponseBusinessSegments =  businessSegmentRepository.GetAll();
            response.ResponseBusinessPartnerSubTypes = businessPartnerSubTypeRepository.GetAll();
            response.ResponsePhoneTypes = phoneTypeRepository.GetAll();
            response.ResponseAddressTypes = addressTypeRepository.GetAll();
            response.ResponseMarketingChannels = marketingChannelRepository.GetAll();
            return response;
        }
        #endregion
    }
}
