using Cares.Interfaces.Repository;
using Cares.Repository.BaseRepository;
using Cares.Repository.Repositories;
using Microsoft.Practices.Unity;

namespace Cares.Repository
{
    /// <summary>
    /// Repository Type Registration
    /// </summary>
    public static class TypeRegistrations
    {
        /// <summary>
        /// Register Types for Repositories
        /// </summary>
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
            unityContainer.RegisterType<IFleetPoolRepository, FleetPoolRepository>();
            unityContainer.RegisterType<ITariffTypeRepository, TariffTypeRepository>();
            unityContainer.RegisterType<ICompanyRepository, CompanyRepository>();
            unityContainer.RegisterType<IBusinessPartnerRepository, BusinessPartnerRepository>();
            unityContainer.RegisterType<IOperationRepository, OperationRepository>();
            unityContainer.RegisterType<IMeasurementUnit, MeasurementUnitRepository>();
            unityContainer.RegisterType<IPaymentTermRepository, PaymentTermRepository>();
            unityContainer.RegisterType<IPricingStrategyRepository, PricingStrategyRepository>();
            unityContainer.RegisterType<IRegionRepository, RegionRepository>();
            unityContainer.RegisterType<BaseDbContext>(new PerRequestLifetimeManager());

            unityContainer.RegisterType<IOrganizationGroupRepository, OrgGroupRepository>();
            unityContainer.RegisterType<IBpRatingTypeRepository, BpRatingTypeRepository>();
            unityContainer.RegisterType<IBusinessLegalStatusRepository, BusinessLegalStatusRepository>();
            unityContainer.RegisterType<IVehicleCategoryRepository, VehicleCategoryRepository>();
            unityContainer.RegisterType<IVehicleMakeRepository, VehicleMakeRepository>();
            unityContainer.RegisterType<IVehicleModelRepository, VehicleModelRepository>();
            unityContainer.RegisterType<IHireGroupRepository, HireGroupRepository>();
            unityContainer.RegisterType<IHireGroupDetailRepository, HireGroupDetailRepository>();
            unityContainer.RegisterType<IStandardRateRepository, StandardRateRepository>();
            unityContainer.RegisterType<IBusinessPartnerIndividualRepository, BusinessPartnerIndividaulRepository>();
            unityContainer.RegisterType<IOccupationTypeRepository, OccupationTypeRepository>();
            unityContainer.RegisterType<IBusinessPartnerCompanyRepository, BusinessPartnerCompanyRepository>();
            unityContainer.RegisterType<ICountryRepository, CountryRepository>();
            unityContainer.RegisterType<IBusinessSegmentRepository, BusinessSegmentRepository>();
            unityContainer.RegisterType<IBusinessPartnerInTypeRepository, BusinessPartnerInTypeRepository>();
            unityContainer.RegisterType<IBusinessPartnerSubTypeRepository, BusinessPartnerSubTypeRepository>();
            unityContainer.RegisterType<IPhoneTypeRepository, PhoneTypeRepository>();
            unityContainer.RegisterType<IAddressTypeRepository, AddressTypeRepository>();
            unityContainer.RegisterType<IStandardRateMainRepository, StandardRateMainRepository>();
            unityContainer.RegisterType<ISubRegionRepository, SubRegionRepository>();
            unityContainer.RegisterType<ICityRepository, CityRepository>();
            unityContainer.RegisterType<IAreaRepository, AreaRepository>();
            unityContainer.RegisterType<IOperationsWorkPlaceRepository, OperationsWorkPlaceRepository>();
            unityContainer.RegisterType<IMarketingChannelRepository, MarketingChannelRepository>();
            unityContainer.RegisterType<IVehicleRepository, VehicleRepository>();
            unityContainer.RegisterType<IHireGroupUpGradeRepository, HireGroupUpGradeRepository>();
            unityContainer.RegisterType<IBusinessPartnerRelationshipTypeRepository, BusinessPartnerRelationshipTypeRepository>();
            unityContainer.RegisterType<IPhoneRepository, PhoneRepository>();
            unityContainer.RegisterType<IAddressRepository, AddressRepository>();
            unityContainer.RegisterType<IBusinessPartnerMarketingChannelRepository, BusinessPartnerMarketingChannelRepository>();
            unityContainer.RegisterType<IBusinessPartnerRelationshipRepository, BusinessPartnerRelationshipRepository>();
            unityContainer.RegisterType<IInsuranceTypeRepository, InsuranceTypeRepository>();
            unityContainer.RegisterType<IInsuranceRtMainRepository, InsuranceRtMainRepository>();
            unityContainer.RegisterType<IInsuranceRtRepository, InsuranceRtRepository>();
            unityContainer.RegisterType<IServiceTypeRepository, ServiceTypeRepository>();
            unityContainer.RegisterType<IServiceItemRepository, ServiceItemRepository>();
            unityContainer.RegisterType<IServiceRtMainRepository, ServiceRtMainRepository>();
            unityContainer.RegisterType<IServiceRtRepository, ServiceRtRepository>();
            unityContainer.RegisterType<IFuelTypeRepository, FuelTypeRepository>();
            unityContainer.RegisterType<IVehicleStatusRepository, VehicleStatusRepository>();
            unityContainer.RegisterType<ITransmissionTypeRepository, TransmissionTypeRepository>();
            unityContainer.RegisterType<IMaintenanceTypeRepository, MaintenanceTypeRepository>();
            unityContainer.RegisterType<IVehicleCheckListRepository, VehicleCheckListRepository>();
            unityContainer.RegisterType<IWorkplaceRepository, WorkplaceRepository>();
            unityContainer.RegisterType<IWorkLocationRepository, WorkLocationRepository>();
            unityContainer.RegisterType<IWorkplaceTypeRepository, WorkplaceTypeRepository>();
            unityContainer.RegisterType<IVehicleCheckListItemRepository, VehicleCheckListItemRepository>();
            unityContainer.RegisterType<IVehicleMaintenanceTypeFrequencyRepository, VehicleMaintenanceTypeFrequencyRepository>();
            unityContainer.RegisterType<IEmpStatusRepository, EmpStatusRepository>();
            unityContainer.RegisterType<IDesignationRepository, DesignationRepository>();
            unityContainer.RegisterType<IDesigGradeRepository, DesigGradeRepository>();
            unityContainer.RegisterType<ILicenseTypeRepository, LicenseTypeRepository>();
            unityContainer.RegisterType<IJobTypeRepository, JobTypeRepository>();

        }
    }
}