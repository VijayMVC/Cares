using Interfaces.IServices;
using Interfaces.Repository;
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

        #endregion
        #region Constructors
        public TariffRateService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IOperationRepository operationRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IHireGroupRepository hireGroupRepository, ITarrifTypeRepository tarrifTypeRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.hireGroupRepository = hireGroupRepository;
            this.tarrifTypeRepository = tarrifTypeRepository;

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
        #endregion
    }
}
