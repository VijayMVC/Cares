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

        #endregion
        #region Constructors
        public TariffRateService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IOperationRepository operationRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IHireGroupRepository hireGroupRepository, ITarrifTypeRepository tarrifTypeRepository, IStandardRateMainRepository standardRateMainRepository, IHireGroupDetailRepository hireGroupDetailRepository)
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

        public TariffRateDetailResponse FindTariffRateById(long id)
        {
            StandardRateMain standardRateMain = standardRateMainRepository.Find(id);
            var hireGroupDetails = hireGroupDetailRepository.GetAll();
            return new TariffRateDetailResponse { StandardRateMain = standardRateMain, HireGroupDetails = hireGroupDetails };
        }
        /// <summary>
        /// Add Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public StandardRateMain AddTariffRate(StandardRateMain standardRateMain)
        {
            standardRateMainRepository.Add(standardRateMain);
            tarrifTypeRepository.SaveChanges();
            return standardRateMain;
        }
        /// <summary>
        /// Update Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public StandardRateMain Update(StandardRateMain standardRateMain)
        {
            standardRateMainRepository.Update(standardRateMain);
            standardRateMainRepository.SaveChanges(); ;
            return standardRateMain;
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
