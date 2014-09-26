using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;
using Repository.BaseRepository;

namespace Cares.Repository.BaseRepository
{
    /// <summary>
    /// Base Db Context. Implements Identity Db Context over Application User
    /// </summary>
    public sealed class BaseDbContext : DbContext
    {
        #region Private
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once NotAccessedField.Local
        private IUnityContainer container;
        #endregion

        #region Protected


        #endregion

        #region Constructor
        public BaseDbContext()
        {
        }
        /// <summary>
        /// Eager load property
        /// </summary>
        public void LoadProperty(object entity, string propertyName, bool isCollection = false)
        {
            if (!isCollection)
            {
                Entry(entity).Reference(propertyName).Load();
            }
            else
            {
                Entry(entity).Collection(propertyName).Load();
            }
        }
        /// <summary>
        /// Eager load property
        /// </summary>
        public void LoadProperty<T>(object entity, Expression<Func<T>> propertyExpression, bool isCollection = false)
        {
            string propertyName = PropertyReference.GetPropertyName(propertyExpression);
            LoadProperty(entity, propertyName, isCollection);
        }

        #endregion

        #region Public

        public BaseDbContext(IUnityContainer container, string connectionString)
            : base(connectionString)
        {
            this.container = container;
        }

        #region Logger
        /// <summary>
        /// Logs
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Log Categories
        /// </summary>
        public DbSet<LogCategory> LogCategories { get; set; }
        /// <summary>
        /// Category Logs
        /// </summary>
        public DbSet<CategoryLog> CategoryLogs { get; set; }
        #endregion
        #region Menu Rights and Security
        /// <summary>
        /// Menu Rights
        /// </summary>
        public DbSet<MenuRight> MenuRights { get; set; }
        /// <summary>
        /// Menu
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
        #endregion

        public DbSet<NrtType> NrtTypes { get; set; }
        public DbSet<NrtMain> NrtMain { get; set; }

        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Companies DB Set
        /// </summary>
        public DbSet<Company> Companies { get; set; }
        /// <summary>
        /// Business Segments DB Set
        /// </summary>
        public DbSet<BusinessSegment> BusinessSegments { get; set; }
        /// <summary>
        /// Organization Groups DB Set
        /// </summary>
        public DbSet<OrgGroup> OrgGroups { get; set; }
        /// <summary>
        /// FleetPool DbSet
        /// </summary>
        public DbSet<FleetPool> FleetPools { get; set; }
        /// <summary>
        /// Countries DB Set
        /// </summary>
        public DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Department DB Set
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        public DbSet<TariffType> TariffTypes { get; set; }
        /// <summary>
        /// Operation DB Set
        /// </summary>
        public DbSet<Operation> Operations { get; set; }
        /// <summary>
        /// Measurement Unit DB Set
        /// </summary>
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        /// <summary>
        /// Business Partner Rating Type DB Set
        /// </summary>
        public DbSet<BpRatingType> BpRatingTypes { get; set; }
        /// <summary>
        /// Business Legal Status DB Set
        /// </summary>
        public DbSet<BusinessLegalStatus> BusinessLegalStatuses { get; set; }
        /// <summary>
        /// Regions DB Set
        /// </summary>
        public DbSet<Region> Regions { get; set; }
        /// <summary>
        /// Regions DB Set
        /// </summary>
        public DbSet<WorkLocation> WorkLocations { get; set; }

        /// <summary>
        /// PricingStrategy DB Set
        /// </summary>
        public DbSet<PricingStrategy> PricingStrategies { get; set; }
        /// <summary>
        /// PaymentTerm DB Set
        /// </summary>
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        /// <summary>
        /// Hire Group Up Grade Db Set
        /// </summary>
        public DbSet<HireGroupUpGrade> HireGroupUpGrades { get; set; }
        /// <summary>
        /// DiscountType DB Set
        /// </summary>
        public DbSet<DiscountType> DiscountTypes { get; set; }

        /// <summary>
        /// Vehicle Models Db Set
        /// </summary>
        public DbSet<VehicleModel> VehicleModels { get; set; }
        /// <summary>
        /// Vehicle Category Db Set
        /// </summary>
        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        /// <summary>
        /// Discount Sub Types Db Set
        /// </summary>
        public DbSet<DiscountSubType> DiscountSubTypes { get; set; }

        /// <summary>
        /// Vehicle Make Db Set
        /// </summary>
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<HireGroup> HireGroups { get; set; }
        public DbSet<HireGroupDetail> HireGroupDetails { get; set; }
        public DbSet<StandardRate> StandardRates { get; set; }
        public DbSet<StandardRateMain> StandardRateMains { get; set; }
        /// <summary>
        /// Business Partner Db Set
        /// </summary>
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        /// <summary>
        /// Business Partner Individuals Db Set
        /// </summary>
        public DbSet<BusinessPartnerIndividual> BusinessPartnerIndividuals { get; set; }
        /// <summary>
        /// Occupation Types Db Set
        /// </summary>
        public DbSet<OccupationType> OccupationTypes { get; set; }
        /// <summary>
        /// Business Partner Companies DbSet
        /// </summary>
        public DbSet<BusinessPartnerCompany> BusinessPartnerCompanies { get; set; }
        /// <summary>
        /// Business Partner SubType DbSet
        /// </summary>
        public DbSet<BusinessPartnerSubType> BusinessPartnerSubTypes { get; set; }
        /// <summary>
        /// Business Partner InType DbSet
        /// </summary>
        public DbSet<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }
        /// <summary>
        /// Phone Type
        /// </summary>
        public DbSet<PhoneType> PhoneTypes { get; set; }
        /// <summary>
        /// Address Type
        /// </summary>
        public DbSet<AddressType> AddressTypes { get; set; }
        /// <summary>
        /// Sub Region DB Set
        /// </summary>
        public DbSet<SubRegion> SubRegions { get; set; }
        /// <summary>
        /// City DB Set
        /// </summary>
        public DbSet<City> Cities { get; set; }
        /// <summary>
        /// Area DB Set
        /// </summary>
        public DbSet<Area> Areas { get; set; }

        /// <summary>
        /// WorkPlaces DB Set
        /// </summary>
        public DbSet<WorkPlace> WorkPlaces { get; set; }

        /// <summary>
        /// WorkPlaceType DB Set
        /// </summary>
        public DbSet<WorkPlaceType> WorkPlaceType { get; set; }

        /// <summary>
        /// Marketing Channel DB Set
        /// </summary>
        public DbSet<MarketingChannel> MarketingChannels { get; set; }

        /// <summary>
        /// OperationsWorkPlaces DB Set
        /// </summary>
        public DbSet<OperationsWorkPlace> OperationsWorkPlaces { get; set; }
        /// <summary>
        /// Business Partner Relationship Types DB Set
        /// </summary>
        public DbSet<BusinessPartnerRelationshipType> BusinessPartnerRelationshipTypes { get; set; }
        /// <summary>
        /// Business Partner Phones Db Set
        /// </summary>
        public DbSet<Phone> Phones { get; set; }
        /// <summary>
        /// Business Partner Address List Db Set
        /// </summary>
        public DbSet<Address> AddressList { get; set; }
        /// <summary>
        /// Business Partner Marketing Channels Db Set
        /// </summary>
        public DbSet<BusinessPartnerMarketingChannel> BusinessPartnerMarketingChannels { get; set; }

        /// <summary>
        /// Business Partner Relationship item list Db Set
        /// </summary>
        public DbSet<BusinessPartnerRelationship> BusinessPartnerRelationships { get; set; }

        /// <summary>
        /// Vehicle DB Set 
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }
        /// <summary>
        /// Insurance Type Db Set
        /// </summary>
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        /// <summary>
        /// Insurance Rate Main Db Set
        /// </summary>
        public DbSet<InsuranceRtMain> InsuranceRtMains { get; set; }
        /// <summary>
        /// Insurance Rate Db Set
        /// </summary>
        public DbSet<InsuranceRt> InsuranceRts { get; set; }

        /// <summary>
        /// Service Type Db Set
        /// </summary>
        public DbSet<ServiceType> ServiceTypes { get; set; }

        /// <summary>
        /// Service Item Db Set
        /// </summary>
        public DbSet<ServiceItem> ServiceItems { get; set; }

        /// <summary>
        /// Service Rate Main  Db Set
        /// </summary>
        public DbSet<ServiceRtMain> ServiceRtMains { get; set; }

        /// <summary>
        /// Service Rate Db Set
        /// </summary>
        public DbSet<ServiceRt> ServiceRts { get; set; }

        /// <summary>
        /// Maintenance Type  Db Set 
        /// </summary>
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }

        /// <summary>
        /// Vehicle Check List  Db Set 
        /// </summary>
        public DbSet<VehicleCheckList> VehicleCheckLists { get; set; }

        /// <summary>
        /// Maintenance Type Group  Db Set 
        /// </summary>
        public DbSet<MaintenanceTypeGroup> MaintenanceTypeGroups { get; set; }

        /// <summary>
        /// Fuel Type  Db Set 
        /// </summary>
        public DbSet<FuelType> FuelTypes { get; set; }

        /// <summary>
        /// Vehicle Status  Db Set 
        /// </summary>
        public DbSet<VehicleStatus> VehicleStatuses { get; set; }

        /// <summary>
        /// Transmission Type  Db Set 
        /// </summary>
        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        /// <summary>
        /// Vehicle Disposal Infos Db Set
        /// </summary>
        public DbSet<VehicleDisposalInfo> VehicleDisposalInfos { get; set; }

        /// <summary>
        /// Vehicle Depreciations Db Set
        /// </summary>
        public DbSet<VehicleDepreciation> VehicleDepreciations { get; set; }

        /// <summary>
        /// Vehicle Maintenance Type Frequencies Db Set
        /// </summary>
        public DbSet<VehicleMaintenanceTypeFrequency> VehicleMaintenanceTypeFrequencies { get; set; }

        /// <summary>
        /// Vehicle Leased Infos Db Set
        /// </summary>
        public DbSet<VehicleLeasedInfo> VehicleLeasedInfos { get; set; }

        /// <summary>
        /// Vehicle Purchase Infos Db Set
        /// </summary>
        public DbSet<VehiclePurchaseInfo> VehiclePurchaseInfos { get; set; }

        /// <summary>
        /// Vehicle Insurance Infos Db Set
        /// </summary>
        public DbSet<VehicleInsuranceInfo> VehicleInsuranceInfos { get; set; }

        /// <summary>
        /// Vehicle Other Details Db Set
        /// </summary>
        public DbSet<VehicleOtherDetail> VehicleOtherDetails { get; set; }

        /// <summary>
        /// Vehicle Check List Item Db Set
        /// </summary>
        public DbSet<VehicleCheckListItem> VehicleCheckListItems { get; set; }

        /// <summary>
        /// Employee Status Db Set
        /// </summary>
        public DbSet<EmpStatus> EmpStatuses { get; set; }

        /// <summary>
        /// Designation Db Set
        /// </summary>
        public DbSet<Designation> Designations { get; set; }

        /// <summary>
        /// Designation Grade Db Set
        /// </summary>
        public DbSet<DesignGrade> DesigGrades { get; set; }

        /// <summary>
        /// License Type Db Set
        /// </summary>
        public DbSet<LicenseType> LicenseTypes { get; set; }

        /// <summary>
        /// Job Type Db Set
        /// </summary>
        public DbSet<JobType> JobTypes { get; set; }

        /// <summary>
        /// Employee Jo bInfo  Db Set
        /// </summary>
        public DbSet<EmpJobInfo> EmpJobInfos { get; set; }

        /// <summary>
        /// Employee Docs Info  Db Set
        /// </summary>
        public DbSet<EmpDocsInfo> EmpDocsInfos { get; set; }

        /// <summary>
        /// Employee Authorized Operations Workplace  Db Set
        /// </summary>
        public DbSet<EmpAuthOperationsWorkplace> EmpAuthOperationsWorkplaces { get; set; }

        /// <summary>
        /// Employee Job Progrss  Db Set
        /// </summary>
        public DbSet<EmpJobProg> EmpJobProgs { get; set; }

        /// <summary>
        /// Additional Driver Charge Db Set
        /// </summary>
        public DbSet<AdditionalDriverCharge> AdditionalDriverCharges { get; set; }

        /// <summary>
        /// Additional Charges Db Set
        /// </summary>
        public DbSet<AdditionalCharge> AdditionalCharges { get; set; }

        /// <summary>
        /// Additional Charge Types
        /// </summary>
        public DbSet<AdditionalChargeType> AdditionalChargeTypes { get; set; }

       /// <summary>
        /// Chauffer Charges Db Set
        /// </summary>
        public DbSet<ChaufferCharge> ChaufferCharges { get; set; }

        /// <summary>
        /// Chauffer Charge Main Db Set
        /// </summary>
        public DbSet<ChaufferChargeMain> ChaufferChargeMains { get; set; }
        
      /// <summary>
        /// Ra Service Items Db Set
        /// </summary>

        public DbSet<RaServiceItem> RaServiceItems { get; set; }




        #endregion
    }
}
