﻿using System.Data.Entity;
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
            unityContainer.RegisterType<ITarrifTypeRepository, TarrifTypeRepository>();
            unityContainer.RegisterType<ICompanyRepository, CompanyRepository>();
            unityContainer.RegisterType<IBusinessPartnerRepository, BusinessPartnerRepository>();
            unityContainer.RegisterType<IOperationRepository, OperationRepository>();
            unityContainer.RegisterType<IMeasurementUnit, MeasurementUnitRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IPaymentTermRepository, PaymentTermRepository>();
            unityContainer.RegisterType<IPricingStrategyRepository, PricingStrategyRepository>();
            unityContainer.RegisterType<IRegionRepository, RegionRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>();
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
            unityContainer.RegisterType<IStandardRateMainRepository, StandardRateMainRepository>();
        }
    }
}