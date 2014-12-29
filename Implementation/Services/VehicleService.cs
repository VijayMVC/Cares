using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Cares.Commons;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.ExceptionHandling;

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
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly IVehicleMaintenanceTypeFrequencyRepository maintenanceTypeFrequencyRepository;
        private readonly IVehicleCheckListItemRepository vehicleCheckListItemRepository;
        private readonly IVehicleImageRepository vehicleImageRepository;
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
            IVehicleModelRepository vehicleModelRepository, IVehicleCategoryRepository vehicleCategoryRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            IVehicleMaintenanceTypeFrequencyRepository maintenanceTypeFrequencyRepository, IVehicleCheckListItemRepository vehicleCheckListItemRepository,
            IVehicleImageRepository vehicleImageRepository)
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
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.maintenanceTypeFrequencyRepository = maintenanceTypeFrequencyRepository;
            this.vehicleCheckListItemRepository = vehicleCheckListItemRepository;
            this.vehicleImageRepository = vehicleImageRepository;
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
            if (request.AllocationStatusKey == (short)AllocationStatusEnum.Replaced)
            {
                request.HireGroupDetailId = 0;
            }
            else if (request.AllocationStatusKey == (short)AllocationStatusEnum.Upgraded)
            {
                // Get Upgraded Hire Groups
                return vehicleRepository.GetUpgradedVehiclesByHireGroup(request);
            }

            return vehicleRepository.GetByHireGroup(request);
        }

        /// <summary>
        /// Get Vehicle Detail By ID
        /// </summary>
        /// <param name="vehicleId">vehicleId</param>
        /// <returns></returns>
        public Vehicle GetVehicleDetail(long vehicleId)
        {
            return vehicleRepository.Find(vehicleId);
        }

        /// <summary>
        /// Save Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Vehicle SaveVehicle(Vehicle vehicle)
        {
            //Check Vehicle Palte Number Duplication check
            if (vehicleRepository.IsVehiclePlateNumberExists(vehicle.PlateNumber, vehicle.VehicleId))
            {
                throw new CaresException(Resources.FleetPool.Vehicle.CodeDuplication);
            }
            Vehicle vehicleDbVersion = vehicleRepository.Find(vehicle.VehicleId);
            vehicle.VehicleCondition = "Not implemented";

            #region Add

            if (vehicleDbVersion == null)
            {
                int numberOfVehiclesByDomainKey = vehicleRepository.GetCountOfVehicleWithDomainKey();
                var domainLicenseDetailwithDomainKey = ClaimHelper.GetDeserializedClaims<DomainLicenseDetailClaim>(CaresUserClaims.DomainLicenseDetail).FirstOrDefault();
                if (domainLicenseDetailwithDomainKey != null)
                    if (domainLicenseDetailwithDomainKey.Vehicles < numberOfVehiclesByDomainKey)
                        throw new CaresException(Resources.Vehicle.Vehicle.ExceedindDomainLimitForVehicleError);
                    else
                        throw new InvalidOperationException(Resources.Vehicle.Vehicle.NoDomainLicenseDetailClaim);

                if (vehicleRepository.DuplicateVehiclePlateNumber(vehicle.PlateNumber, vehicle.VehicleId))
                {
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Vehicle.Vehicle.DuplicatePlateNumber));
                }
                vehicle.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.IsActive = true;
                vehicle.IsReadOnly = vehicle.IsPrivate = vehicle.IsDeleted = false;
                vehicle.RecLastUpdatedDt = vehicle.RecCreatedDt = DateTime.Now;
                vehicle.RecLastUpdatedBy = vehicle.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.RowVersion = 0;
                vehicle.VehicleCode = "CaresVehicle";

                #region Other detail
                vehicle.VehicleOtherDetail.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehicleOtherDetail.IsActive = true;
                vehicle.VehicleOtherDetail.IsReadOnly = vehicle.VehicleOtherDetail.IsPrivate = vehicle.VehicleOtherDetail.IsDeleted = false;
                vehicle.VehicleOtherDetail.RecLastUpdatedDt = vehicle.VehicleOtherDetail.RecCreatedDt = DateTime.Now;
                vehicle.VehicleOtherDetail.RecLastUpdatedBy = vehicle.VehicleOtherDetail.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleOtherDetail.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleOtherDetail.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleOtherDetail.RowVersion = 0;
                #endregion

                #region Purchase Info
                vehicle.VehiclePurchaseInfo.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehiclePurchaseInfo.RecLastUpdatedDt = vehicle.VehiclePurchaseInfo.RecCreatedDt = DateTime.Now;
                vehicle.VehiclePurchaseInfo.RecLastUpdatedBy = vehicle.VehiclePurchaseInfo.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehiclePurchaseInfo.RowVersion = 0;
                #endregion

                #region Leased Info
                vehicle.VehicleLeasedInfo.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehicleLeasedInfo.RecLastUpdatedDt = vehicle.VehicleLeasedInfo.RecCreatedDt = DateTime.Now;
                vehicle.VehicleLeasedInfo.RecLastUpdatedBy = vehicle.VehicleLeasedInfo.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleLeasedInfo.RowVersion = 0;
                #endregion

                #region Insurance Info
                vehicle.VehicleInsuranceInfo.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehicleInsuranceInfo.RecLastUpdatedDt = vehicle.VehicleInsuranceInfo.RecCreatedDt = DateTime.Now;
                vehicle.VehicleInsuranceInfo.RecLastUpdatedBy = vehicle.VehicleInsuranceInfo.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleInsuranceInfo.RowVersion = 0;
                #endregion

                #region Dericiation Info
                vehicle.VehicleDepreciation.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehicleDepreciation.RecLastUpdatedDt = vehicle.VehicleDepreciation.RecCreatedDt = DateTime.Now;
                vehicle.VehicleDepreciation.RecLastUpdatedBy = vehicle.VehicleDepreciation.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleDepreciation.RowVersion = 0;
                #endregion

                #region Disposal Info
                vehicle.VehicleDisposalInfo.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicle.VehicleDisposalInfo.RecLastUpdatedDt = vehicle.VehicleDisposalInfo.RecCreatedDt = DateTime.Now;
                vehicle.VehicleDisposalInfo.RecLastUpdatedBy = vehicle.VehicleDisposalInfo.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicle.VehicleDisposalInfo.RowVersion = 0;
                //Vehicle Maintenance Type Frequency Items
                if (vehicle.VehicleMaintenanceTypeFrequencies != null)
                {
                    foreach (var item in vehicle.VehicleMaintenanceTypeFrequencies)
                    {
                        item.UserDomainKey = vehicleRepository.UserDomainKey;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }
                #endregion

                #region Vehicle Check List Item List
                if (vehicle.VehicleCheckListItems != null)
                {
                    foreach (var item in vehicle.VehicleCheckListItems)
                    {
                        item.UserDomainKey = vehicleRepository.UserDomainKey;
                        item.IsReadOnly = item.IsPrivate = vehicle.IsDeleted = false;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }
                #endregion

                vehicleRepository.Add(vehicle);

            }
            #endregion

            #region Edit
            else
            {


                vehicleDbVersion.IsBranchOwner = vehicle.IsBranchOwner;
                vehicleDbVersion.PlateNumber = vehicle.PlateNumber;
                vehicleDbVersion.VehicleName = vehicle.VehicleName;
                vehicleDbVersion.ModelYear = vehicle.ModelYear;
                vehicleDbVersion.FleetPoolId = vehicle.FleetPoolId;
                vehicleDbVersion.Color = vehicle.Color;
                vehicleDbVersion.OperationsWorkPlaceId = vehicle.OperationsWorkPlaceId;
                vehicleDbVersion.FuelLevel = vehicle.FuelLevel;
                vehicleDbVersion.TankSize = vehicle.TankSize;
                vehicleDbVersion.InitialOdometer = vehicle.InitialOdometer;
                vehicleDbVersion.CurrentOdometer = vehicle.CurrentOdometer;
                vehicleDbVersion.RegistrationDate = vehicle.RegistrationDate;
                vehicleDbVersion.VehicleMakeId = vehicle.VehicleMakeId;
                vehicleDbVersion.VehicleCategoryId = vehicle.VehicleCategoryId;
                vehicleDbVersion.VehicleModelId = vehicle.VehicleModelId;
                vehicleDbVersion.VehicleStatusId = vehicle.VehicleStatusId;
                vehicleDbVersion.FuelTypeId = vehicle.FuelTypeId;
                vehicleDbVersion.TransmissionTypeId = vehicle.TransmissionTypeId;
                vehicleDbVersion.RegistrationExpiryDate = vehicle.RegistrationExpiryDate;
                vehicleDbVersion.VehicleCondition = vehicle.VehicleCondition;

                #region Vehicle other Detail
                vehicleDbVersion.VehicleOtherDetail.NumberOfDoors = vehicle.VehicleOtherDetail.NumberOfDoors;
                vehicleDbVersion.VehicleOtherDetail.HorsePower_CC = vehicle.VehicleOtherDetail.HorsePower_CC;
                vehicleDbVersion.VehicleOtherDetail.NumberOfCylinders = vehicle.VehicleOtherDetail.NumberOfCylinders;
                vehicleDbVersion.VehicleOtherDetail.IsAlloyRim = vehicle.VehicleOtherDetail.IsAlloyRim;
                vehicleDbVersion.VehicleOtherDetail.ChasisNumber = vehicle.VehicleOtherDetail.ChasisNumber;
                vehicleDbVersion.VehicleOtherDetail.EngineNumber = vehicle.VehicleOtherDetail.EngineNumber;
                vehicleDbVersion.VehicleOtherDetail.KeyCode = vehicle.VehicleOtherDetail.KeyCode;
                vehicleDbVersion.VehicleOtherDetail.RadioCode = vehicle.VehicleOtherDetail.RadioCode;
                vehicleDbVersion.VehicleOtherDetail.Accessories = vehicle.VehicleOtherDetail.Accessories;
                vehicleDbVersion.VehicleOtherDetail.TopSpeed = vehicle.VehicleOtherDetail.TopSpeed;
                vehicleDbVersion.VehicleOtherDetail.InteriorDescription = vehicle.VehicleOtherDetail.InteriorDescription;
                vehicleDbVersion.VehicleOtherDetail.FrontWheelSize = vehicle.VehicleOtherDetail.FrontWheelSize;
                vehicleDbVersion.VehicleOtherDetail.BackWheelSize = vehicle.VehicleOtherDetail.BackWheelSize;
                vehicleDbVersion.VehicleOtherDetail.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehicleOtherDetail.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Purchase Info
                vehicleDbVersion.VehiclePurchaseInfo.PurchaseDate = vehicle.VehiclePurchaseInfo.PurchaseDate;
                vehicleDbVersion.VehiclePurchaseInfo.PurchaseDescription = vehicle.VehiclePurchaseInfo.PurchaseDescription;
                vehicleDbVersion.VehiclePurchaseInfo.PurchasedFrom = vehicle.VehiclePurchaseInfo.PurchasedFrom;
                vehicleDbVersion.VehiclePurchaseInfo.PurchaseOrderNumber = vehicle.VehiclePurchaseInfo.PurchaseOrderNumber;
                vehicleDbVersion.VehiclePurchaseInfo.PurchaseCost = vehicle.VehiclePurchaseInfo.PurchaseCost;
                vehicleDbVersion.VehiclePurchaseInfo.IsUsedVehicle = vehicle.VehiclePurchaseInfo.IsUsedVehicle;
                vehicleDbVersion.VehiclePurchaseInfo.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehiclePurchaseInfo.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Leased Info
                vehicleDbVersion.VehicleLeasedInfo.DownPayment = vehicle.VehicleLeasedInfo.DownPayment;
                vehicleDbVersion.VehicleLeasedInfo.LeasedStartDate = vehicle.VehicleLeasedInfo.LeasedStartDate;
                vehicleDbVersion.VehicleLeasedInfo.LeasedFinishDate = vehicle.VehicleLeasedInfo.LeasedFinishDate;
                vehicleDbVersion.VehicleLeasedInfo.MonthlyPayment = vehicle.VehicleLeasedInfo.MonthlyPayment;
                vehicleDbVersion.VehicleLeasedInfo.LeasedFrom = vehicle.VehicleLeasedInfo.LeasedFrom;
                vehicleDbVersion.VehicleLeasedInfo.InterestRate = vehicle.VehicleLeasedInfo.InterestRate;
                vehicleDbVersion.VehicleLeasedInfo.PrinicipalPayment = vehicle.VehicleLeasedInfo.PrinicipalPayment;
                vehicleDbVersion.VehicleLeasedInfo.FirstPaymentDate = vehicle.VehicleLeasedInfo.FirstPaymentDate;
                vehicleDbVersion.VehicleLeasedInfo.LastMonthPayment = vehicle.VehicleLeasedInfo.LastMonthPayment;
                vehicleDbVersion.VehicleLeasedInfo.LeaseToOwnership = vehicle.VehicleLeasedInfo.LeaseToOwnership;
                vehicleDbVersion.VehicleLeasedInfo.FirstMonthPayment = vehicle.VehicleLeasedInfo.FirstMonthPayment;
                vehicleDbVersion.VehicleLeasedInfo.BPMainId = vehicle.VehicleLeasedInfo.BPMainId;
                vehicleDbVersion.VehicleLeasedInfo.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehicleLeasedInfo.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Insurance Info
                vehicleDbVersion.VehicleInsuranceInfo.InsuranceAgent = vehicle.VehicleInsuranceInfo.InsuranceAgent;
                vehicleDbVersion.VehicleInsuranceInfo.CoverageLimit = vehicle.VehicleInsuranceInfo.CoverageLimit;
                vehicleDbVersion.VehicleInsuranceInfo.RenewalDate = vehicle.VehicleInsuranceInfo.RenewalDate;
                vehicleDbVersion.VehicleInsuranceInfo.InsuranceDate = vehicle.VehicleInsuranceInfo.InsuranceDate;
                vehicleDbVersion.VehicleInsuranceInfo.Premium = vehicle.VehicleInsuranceInfo.Premium;
                vehicleDbVersion.VehicleInsuranceInfo.InsuredFrom = vehicle.VehicleInsuranceInfo.InsuredFrom;
                vehicleDbVersion.VehicleInsuranceInfo.BPMainId = vehicle.VehicleInsuranceInfo.BPMainId;
                vehicleDbVersion.VehicleInsuranceInfo.InsuranceTypeId = vehicle.VehicleInsuranceInfo.InsuranceTypeId;
                vehicleDbVersion.VehicleInsuranceInfo.InsuredValue = vehicle.VehicleInsuranceInfo.InsuredValue;
                vehicleDbVersion.VehicleInsuranceInfo.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehicleInsuranceInfo.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Dereciation Info
                vehicleDbVersion.VehicleDepreciation.UsefulPeriodStartDate = vehicle.VehicleDepreciation.UsefulPeriodStartDate;
                vehicleDbVersion.VehicleDepreciation.FirstMonthDepAmount = vehicle.VehicleDepreciation.FirstMonthDepAmount;
                vehicleDbVersion.VehicleDepreciation.MonthlyDepAmount = vehicle.VehicleDepreciation.MonthlyDepAmount;
                vehicleDbVersion.VehicleDepreciation.LastMonthDepAmount = vehicle.VehicleDepreciation.LastMonthDepAmount;
                vehicleDbVersion.VehicleDepreciation.ResidualValue = vehicle.VehicleDepreciation.ResidualValue;
                vehicleDbVersion.VehicleDepreciation.UsefulPeriodEndDate = vehicle.VehicleDepreciation.UsefulPeriodEndDate;
                vehicleDbVersion.VehicleDepreciation.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehicleDepreciation.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Disposal Info
                vehicleDbVersion.VehicleDisposalInfo.SaleDate = vehicle.VehicleDisposalInfo.SaleDate;
                vehicleDbVersion.VehicleDisposalInfo.SalePrice = vehicle.VehicleDisposalInfo.SalePrice;
                vehicleDbVersion.VehicleDisposalInfo.SoldTo = vehicle.VehicleDisposalInfo.SoldTo;
                vehicleDbVersion.VehicleDisposalInfo.DisposalDescription = vehicle.VehicleDisposalInfo.DisposalDescription;
                vehicleDbVersion.VehicleDisposalInfo.BPMainId = vehicle.VehicleDisposalInfo.BPMainId;
                vehicleDbVersion.VehicleDisposalInfo.RecLastUpdatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleDbVersion.VehicleDisposalInfo.RecLastUpdatedDt = DateTime.Now;
                #endregion

                #region Vehicle Maintenance Type Frequency Items
                //Add vehicle maintenenace items
                if (vehicle.VehicleMaintenanceTypeFrequencies != null)
                {
                    foreach (var item in vehicle.VehicleMaintenanceTypeFrequencies)
                    {
                        if (
                            vehicleDbVersion.VehicleMaintenanceTypeFrequencies.All(
                                x =>
                                    x.MaintenanceTypeFrequencyId != item.MaintenanceTypeFrequencyId ||
                                    item.MaintenanceTypeFrequencyId == 0))
                        {
                            item.UserDomainKey = vehicleRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            vehicleDbVersion.VehicleMaintenanceTypeFrequencies.Add(item);
                        }
                    }
                }
                //find missing items
                List<VehicleMaintenanceTypeFrequency> missingItems = new List<VehicleMaintenanceTypeFrequency>();
                foreach (VehicleMaintenanceTypeFrequency dbversionItemeMaintenanceTypeFrequency in vehicleDbVersion.VehicleMaintenanceTypeFrequencies)
                {
                    if (vehicle.VehicleMaintenanceTypeFrequencies != null && vehicle.VehicleMaintenanceTypeFrequencies.All(x => x.MaintenanceTypeFrequencyId != dbversionItemeMaintenanceTypeFrequency.MaintenanceTypeFrequencyId))
                    {
                        missingItems.Add(dbversionItemeMaintenanceTypeFrequency);
                    }
                    if (vehicle.VehicleMaintenanceTypeFrequencies == null)
                    {
                        missingItems.Add(dbversionItemeMaintenanceTypeFrequency);
                    }
                }
                //remove missing items
                foreach (VehicleMaintenanceTypeFrequency missingMaintenanceTypeFrequency in missingItems)
                {
                    VehicleMaintenanceTypeFrequency dbVersionMissingItem = vehicleDbVersion.VehicleMaintenanceTypeFrequencies.First(x => x.MaintenanceTypeFrequencyId == missingMaintenanceTypeFrequency.MaintenanceTypeFrequencyId);
                    if (dbVersionMissingItem.MaintenanceTypeFrequencyId > 0)
                    {
                        vehicleDbVersion.VehicleMaintenanceTypeFrequencies.Remove(dbVersionMissingItem);
                        maintenanceTypeFrequencyRepository.Delete(dbVersionMissingItem);
                        maintenanceTypeFrequencyRepository.SaveChanges();
                    }
                }

                #endregion

                #region Vehicle CheckList Items
                //Add  Vehicle CheckList Items
                if (vehicle.VehicleCheckListItems != null)
                {
                    foreach (var item in vehicle.VehicleCheckListItems)
                    {
                        if (
                            vehicleDbVersion.VehicleCheckListItems.All(
                                x =>
                                    x.VehicleCheckListItemId != item.VehicleCheckListItemId ||
                                    item.VehicleCheckListItemId == 0))
                        {
                            item.UserDomainKey = vehicleRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            vehicleDbVersion.VehicleCheckListItems.Add(item);
                        }
                    }
                }
                //find missing items
                List<VehicleCheckListItem> missingCheckListItems = new List<VehicleCheckListItem>();
                foreach (VehicleCheckListItem dbversionCheckListItem in vehicleDbVersion.VehicleCheckListItems)
                {
                    if (vehicle.VehicleCheckListItems != null && vehicle.VehicleCheckListItems.All(x => x.VehicleCheckListItemId != dbversionCheckListItem.VehicleCheckListItemId))
                    {
                        missingCheckListItems.Add(dbversionCheckListItem);
                    }
                    if (vehicle.VehicleMaintenanceTypeFrequencies == null)
                    {
                        missingCheckListItems.Add(dbversionCheckListItem);
                    }
                }
                //remove missing items
                foreach (VehicleCheckListItem missingCheckListItem in missingCheckListItems)
                {
                    VehicleCheckListItem dbVersionMissingItem = vehicleDbVersion.VehicleCheckListItems.First(x => x.VehicleCheckListItemId == missingCheckListItem.VehicleCheckListItemId);
                    if (dbVersionMissingItem.VehicleCheckListItemId > 0)
                    {
                        vehicleDbVersion.VehicleCheckListItems.Remove(dbVersionMissingItem);
                        vehicleCheckListItemRepository.Delete(dbVersionMissingItem);
                        vehicleCheckListItemRepository.SaveChanges();
                    }
                }

                #endregion

            }
            vehicleRepository.SaveChanges();
            #endregion
            Vehicle vehicleResponse = vehicleRepository.Find(vehicle.VehicleId);
            return vehicleResponse;
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
                   Locations = operationsWorkPlaceRepository.GetSalesOperationsWorkPlace()
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


        /// <summary>
        /// Get Vehicle Info For NRT
        /// </summary>
        /// <param name="operationWorkPlaceId"></param>
        /// <param name="startDtTime"></param>
        /// <param name="endDtTime"></param>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetVehicleInfoForNrt(long operationWorkPlaceId, DateTime startDtTime, DateTime endDtTime)
        {
            return vehicleRepository.GetVehicleInfoForNrt(operationWorkPlaceId, startDtTime, endDtTime);
        }

        /// <summary>
        /// Save Vehicle Image
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="vehilceId"></param>
        public void SaveVehicleImage(MemoryStream fileStream, long vehilceId)
        {
            Vehicle vehicle = vehicleRepository.Find(vehilceId);
            if (vehicle.VehicleImages != null)
            {
                foreach (var item in vehicle.VehicleImages)
                {
                    item.Image = fileStream.ToArray();
                }
            }
            else
            {
                VehicleImage vehicleImage = new VehicleImage();
                vehicleImage.UserDomainKey = vehicleRepository.UserDomainKey;
                vehicleImage.RecLastUpdatedDt = vehicleImage.RecCreatedDt = DateTime.Now;
                vehicleImage.RecLastUpdatedBy = vehicleImage.RecCreatedBy = vehicleRepository.LoggedInUserIdentity;
                vehicleImage.RowVersion = 0;
                vehicleImage.VehicleImageCode = "COde";
                vehicleImage.VehicleImageName = "Name";
                vehicleImage.VehicleImageDescription = "Des";
                vehicleImage.Image = fileStream.ToArray();
                vehicleImage.VehicleId = vehilceId;
                vehicleImageRepository.Add(vehicleImage);
                vehicleImageRepository.SaveChanges();
            }

            vehicleRepository.SaveChanges();


        }

        #endregion

    }
}
