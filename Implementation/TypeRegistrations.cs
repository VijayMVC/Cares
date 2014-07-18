using Implementation.Identity;
using Implementation.Services;
using Interfaces.IServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Models.IdentityModels;
using Repository.Repositories;

namespace Implementation
{
    public static class TypeRegistrations
    {
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
        }
    }
}
