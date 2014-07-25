using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// Tariff Rate Service
    /// </summary>
    public sealed class TariffRateService : ITariffRateService
    {
        #region Private
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        private readonly IHireGroupRepository hireGroupRepository;
        private readonly ITarrifTypeRepository tarrifTypeRepository;
        private readonly IStandardRateMainRepository standardRateMainRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IStandardRateRepository standardRateRepository;

        #endregion
        #region Constructors
        public TariffRateService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IOperationRepository operationRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IHireGroupRepository hireGroupRepository, ITarrifTypeRepository tarrifTypeRepository, IStandardRateMainRepository standardRateMainRepository,
            IHireGroupDetailRepository hireGroupDetailRepository, IStandardRateRepository standardRateRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.hireGroupRepository = hireGroupRepository;
            this.tarrifTypeRepository = tarrifTypeRepository;
            this.standardRateMainRepository = standardRateMainRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.standardRateRepository = standardRateRepository;


        }
        #endregion
        #region Public
        public TariffRateBaseResponse GetBaseData()
        {
            return new TariffRateBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                HireGroups = hireGroupRepository.GetAll(),
                VehicleModels = vehicleModelRepository.GetAll(),
                VehicleMakes = vehicleMakeRepository.GetAll(),
                VehicleCategories = vehicleCategoryRepository.GetAll(),
                TariffTypes = tarrifTypeRepository.GetAll(),
            };
        }
        public TariffRateResponse LoadTariffRates(TariffRateRequest tariffRateRequest)
        {
            return standardRateMainRepository.GetTariffRates(tariffRateRequest);
        }
        /// <summary>
        ///Get Hire Group Detail List
        /// </summary>
        /// <returns>Hire Group Detail Response</returns>
        public HireGroupDetailResponse GetHireGroupDetailsForTariffRate()
        {
            return hireGroupDetailRepository.GetHireGroupDetailsForTariffRate();
        }
        /// <summary>
        /// Find Standard Rate Main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StandardRateMain Find(long id)
        {
            return standardRateMainRepository.Find(id);
        }
        /// <summary>
        /// Add Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public void AddTariffRate(StandardRateMain standardRateMain)
        {
            standardRateMain.RecCreatedDt = System.DateTime.Now;
            standardRateMain.RecLastUpdatedDt = System.DateTime.Now;
            standardRateMainRepository.Add(standardRateMain);
            standardRateMainRepository.SaveChanges();

        }
        /// <summary>
        /// Update Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public void Update(StandardRateMain standardRateMain)
        {
            standardRateMain.RecCreatedDt = System.DateTime.Now;
            standardRateMain.RecLastUpdatedDt = System.DateTime.Now;
            standardRateMainRepository.Update(standardRateMain);
            standardRateMainRepository.SaveChanges(); ;

        }
        /// <summary>
        /// Delete Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        public void DeleteTariffRate(StandardRateMain standardRateMain)
        {
            standardRateMainRepository.Delete(standardRateMain);
            standardRateMainRepository.SaveChanges();
        }
        #endregion
    }
}
