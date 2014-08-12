using Cares.Implementation.Identity;
using Cares.Implementation.Services;
using Cares.Interfaces.IServices;
using Cares.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace Cares.Implementation
{
    /// <summary>
    /// Type Registration for Implemention 
    /// </summary>
    public static class TypeRegistrations
    {
        /// <summary>
        /// Register Types for Implementation
        /// </summary>
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IEmployeeService, EmployeeService>();
            unityContainer.RegisterType<IDepartmentService, DepartmentService>();
            unityContainer.RegisterType<IFleetPoolService, FleetPoolService>();
            unityContainer.RegisterType<ITarrifTypeService, TarrifTypeService>();
            unityContainer.RegisterType<ICompanyService, CompanyService>();
            unityContainer.RegisterType<IMeasurementUnitService, MeasurementUnitService>();
            unityContainer.RegisterType<IOperationService, OperationService>();
            unityContainer.RegisterType<IPricingStrategyService, PricingStrategyService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            unityContainer.RegisterType<IBusinessPartnerService, BusinessPartnerService>();
            unityContainer.RegisterType<IPaymentTermService, PaymentTermService>();
            unityContainer.RegisterType<IBPRatingTypeService, BPRatingTypeService>();
            unityContainer.RegisterType<IBusinessLegalStatusService, BusinessLegalStatusService>();
            unityContainer.RegisterType<IBusinessPartnerBaseDataService, BusinessPartnerBaseDataService>();
            unityContainer.RegisterType<ITariffRateService, TariffRateService>();
            unityContainer.RegisterType<IBusinessPartnerCompanyService, BusinessPartnerCompanyService>();
            unityContainer.RegisterType<IStandardRateService, StandardRateService>();
            unityContainer.RegisterType<IBusinessPartnerIndividualService, BusinessPartnerIndividualService>();
            unityContainer.RegisterType<IOccupationTypeService, OccupationTypeService>();
            unityContainer.RegisterType<ICountryService, CountryService>();            
            unityContainer.RegisterType<IHireGroupService, HireGroupService>();
            unityContainer.RegisterType<IAddressBaseDataService, AddressBaseDataService>();
            unityContainer.RegisterType<IRentalAgreementService, RentalAgreementService>();
        }
    }
}