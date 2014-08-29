using System;
using System.Globalization;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Vehicle Service
    /// </summary>
    public class VehicleService : IVehicleService
    {


        #region Private

        private readonly IVehicleRepository vehicleRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IFleetPoolRepository fleetPoolRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IRegionRepository regionRepository;
        private readonly IFuelTypeRepository fuelTypeRepository;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ITransmissionTypeRepository transmissionTypeResposirory;
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        private readonly IInsuranceTypeRepository insuranceTypeRepository;
        private readonly IMaintenanceTypeRepository maintenanceTypeRepository;
        private readonly IVehicleCheckListRepository vehicleCheckListRepository;
         private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleService(IVehicleRepository vehicleRepository, IOperationRepository operationRepository, IFleetPoolRepository fleetPoolRepository,
            ICompanyRepository companyRepository, IRegionRepository regionRepository, IFuelTypeRepository fuelTypeRepository,
            IVehicleMakeRepository vehicleMakeRepository, IVehicleStatusRepository vehicleStatusRepository, IDepartmentRepository departmentRepository,
               ITransmissionTypeRepository transmissionTypeResposirory, IBusinessPartnerRepository businessPartnerRepository,
            IInsuranceTypeRepository insuranceTypeRepository, IMaintenanceTypeRepository maintenanceTypeRepository, IVehicleCheckListRepository vehicleCheckListRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleCategoryRepository vehicleCategoryRepository)
        {
            if (vehicleRepository == null)
            {
                throw new ArgumentNullException("vehicleRepository");
            }

            this.vehicleRepository = vehicleRepository;
            this.operationRepository = operationRepository;
            this.fleetPoolRepository = fleetPoolRepository;
            this.companyRepository = companyRepository;
            this.regionRepository = regionRepository;
            this.fuelTypeRepository = fuelTypeRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.departmentRepository = departmentRepository;
            this.transmissionTypeResposirory = transmissionTypeResposirory;
            this.businessPartnerRepository = businessPartnerRepository;
            this.insuranceTypeRepository = insuranceTypeRepository;
            this.maintenanceTypeRepository = maintenanceTypeRepository;
            this.vehicleCheckListRepository = vehicleCheckListRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Vehicles List Based on search Criteria
        /// </summary>
        /// <returns></returns>
        public GetVehicleResponse LoadVehicles(VehicleSearchRequest request)
        {
            return vehicleRepository.GetVehicles(request);
        }

        /// <summary>
        /// Get By Hire Group
        /// </summary>
        public GetVehicleResponse GetByHireGroup(VehicleSearchRequest request)
        {
            return vehicleRepository.GetByHireGroup(request);
        }

        /// <summary>
        /// Get Vehicle By Id
        /// </summary>
        public Vehicle GetById(long vehicleId)
        {
            Vehicle vehicle = vehicleRepository.Find(vehicleId);
            if (vehicle == null)
            {
                throw new ApplicationException(string.Format(CultureInfo.InvariantCulture, "Vehicle with Id {0} not found!", vehicleId));
            }
            return vehicleRepository.Find(vehicleId);
        }

        /// <summary>
        /// Get Base Data
        /// </summary>
        /// <returns></returns>
        public VehicleBaseDataResponse GetBaseData()
        {
            return new VehicleBaseDataResponse
               {
                   Operations = operationRepository.GetAll(),
                   FleetPools = fleetPoolRepository.GetAll(),
                   Companies = companyRepository.GetAll(),
                   Regions = regionRepository.GetAll(),
                   FuelTypes = fuelTypeRepository.GetAll(),
                   VehicleModels = vehicleModelRepository.GetAll(),
                   VehicleStatuses = vehicleStatusRepository.GetAll(),
                   Departments = departmentRepository.GetAll(),
                   VehicleCategories = vehicleCategoryRepository.GetAll(),
                   TransmissionTypes = transmissionTypeResposirory.GetAll(),
                   VehicleMakes = vehicleMakeRepository.GetAll(),
                   BusinessPartners = businessPartnerRepository.GetAll(),
                   InsuranceType = insuranceTypeRepository.GetAll(),
                   MaintenanceTypes = maintenanceTypeRepository.GetAll(),
                   VehicleCheckList = vehicleCheckListRepository.GetAll(),

               };
        }

        /// <summary>
        /// Delete Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public void DeleteVehicle(Vehicle vehicle)
        {
            vehicleRepository.Delete(vehicle);
            vehicleRepository.SaveChanges();
        }

        /// <summary>
        /// Find By Vehicle Id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public Vehicle FindById(long vehicleId)
        {
            return vehicleRepository.Find(vehicleId);
        }
        #endregion

    }
}
