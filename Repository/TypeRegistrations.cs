using System.Data.Entity;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Repository.BaseRepository;
using Repository.Repositories;

namespace Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
            unityContainer.RegisterType<IFleetPoolRepository, FleetPoolRepository>();
            unityContainer.RegisterType<ITarrifTypeRepository, TarrifTypeRepository>();
            unityContainer.RegisterType<ICompanyRepository, CompanyRepository>();
            unityContainer.RegisterType<IBusinessPartnerRepository, BusinessPartnerRepository>();
            unityContainer.RegisterType<IOperationRepository, OperationRepository>();
            unityContainer.RegisterType<IMeasurementUnit, MeasurementUnitRepository>();
            unityContainer.RegisterType<IPaymentTermRepository, PaymentTermRepository>();
            unityContainer.RegisterType<IPricingStrategyRepository, PricingStrategyRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>();
            unityContainer.RegisterType<IBpRatingTypeRepository ,BpRatingTypeRepository>();
            unityContainer.RegisterType<IBusinessLegalStatusRepository, BusinessLegalStatusRepository>();

            unityContainer.RegisterType<DbContext, BaseDbContext>(new HierarchicalLifetimeManager());
        }
    }
}
