using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Seasonal Discount Service
    /// </summary>
    public class SeasonalDiscountService : ISeasonalDiscountService
    {
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly ISeasonalDiscountRepository seasonalDiscountRepository;
        private readonly ISeasonalDiscountMainRepository seasonalDiscountMainRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IHireGroupRepository hireGroupRepository;
        private readonly IBpRatingTypeRepository ratingTypeRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public SeasonalDiscountService(ISeasonalDiscountRepository seasonalDiscountRepository,
            ISeasonalDiscountMainRepository seasonalDiscountMainRepository, ICompanyRepository companyRepository,
            IDepartmentRepository departmentRepository, IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
            IHireGroupRepository hireGroupRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository, IBpRatingTypeRepository ratingTypeRepository)
        {
            this.seasonalDiscountRepository = seasonalDiscountRepository;
            this.seasonalDiscountMainRepository = seasonalDiscountMainRepository;
            this.companyRepository = companyRepository;
            this.departmentRepository = departmentRepository;
            this.operationRepository = operationRepository;
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.hireGroupRepository = hireGroupRepository;
            this.ratingTypeRepository = ratingTypeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Seasonal Discount Base data
        /// </summary>
        public SeasonalDiscountBaseResponse GetBaseData()
        {
            return new SeasonalDiscountBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                TariffTypes = tariffTypeRepository.GetAll(),
                OperationsWorkPlaces = operationsWorkPlaceRepository.GetAll(),
                VehicleCategories = vehicleCategoryRepository.GetAll(),
                VehicleModels = vehicleModelRepository.GetAll(),
                VehicleMakes = vehicleMakeRepository.GetAll(),
                HireGroups = hireGroupRepository.GetAll(),
                BpRatingTypes = ratingTypeRepository.GetAll(),
            };
        }

        /// <summary>
        /// Load Seasonal Discount Main Based on search criteria
        /// </summary>
        /// <returns></returns>
        public SeasonalDiscountSearchResponse LoadAll(SeasonalDiscountSearchRequest request)
        {
            return seasonalDiscountMainRepository.GetSeasonalDiscounts(request);
        }

        /// <summary>
        /// Save Seasonal Discount Main
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        /// <returns></returns>
        public SeasonalDiscountMainContent SaveSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain)
        {
            SeasonalDiscountMain seasonalDiscountMainDbVersion =
             seasonalDiscountMainRepository.Find(seasonalDiscountMain.SeasonalDiscountMainId);
            TariffType tariffType = tariffTypeRepository.Find(long.Parse(seasonalDiscountMain.TariffTypeCode));
            seasonalDiscountMain.TariffTypeCode = tariffType.TariffTypeCode;
            if (seasonalDiscountMainDbVersion == null) //Add Case
            {
                AddSeasonalDiscount(seasonalDiscountMain);
            }
            else //Update
            {
                UpdateSeasonalDiscount(seasonalDiscountMain, seasonalDiscountMainDbVersion);
            }
            return null;
        }

        /// <summary>
        /// Update Seasonal Discount
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        /// <param name="seasonalDiscountMainDbVersion"></param>
        private void UpdateSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain,
            SeasonalDiscountMain seasonalDiscountMainDbVersion)
        {
            seasonalDiscountMainDbVersion.RecLastUpdatedBy = seasonalDiscountMainRepository.LoggedInUserIdentity;
            seasonalDiscountMainDbVersion.RecLastUpdatedDt = DateTime.Now;
            seasonalDiscountMainDbVersion.StartDt = seasonalDiscountMain.StartDt;
            if (seasonalDiscountMain.SeasonalDiscounts != null)
            {
                //Validate Chauffer Charge Main
                //ChaufferChargeValidation(chaufferChargeMain, false);

                foreach (var item in seasonalDiscountMain.SeasonalDiscounts)
                {
                    if (
                        seasonalDiscountMainDbVersion.SeasonalDiscounts.All(
                            x =>
                                x.SeasonalDiscountId != item.SeasonalDiscountId ||
                                item.SeasonalDiscountId == 0))
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy =
                            item.RecCreatedBy = seasonalDiscountMainRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.RevisionNumber = 0;
                        item.UserDomainKey = seasonalDiscountMainRepository.UserDomainKey;
                        seasonalDiscountMainDbVersion.SeasonalDiscounts.Add(item);
                    }
                    else
                    {
                        if (seasonalDiscountMainDbVersion.SeasonalDiscounts.Any(
                            x =>
                                x.SeasonalDiscountId == item.SeasonalDiscountId))
                        {
                            SeasonalDiscount seasonalDiscountDbVesion =
                                seasonalDiscountMainDbVersion.SeasonalDiscounts.First(
                                    x => x.SeasonalDiscountId == item.SeasonalDiscountId);
                            if (seasonalDiscountDbVesion.OperationsWorkPlaceId != item.OperationsWorkPlaceId ||
                                seasonalDiscountDbVesion.CustomerType != item.CustomerType
                                || seasonalDiscountDbVesion.BpRatingTypeId != item.BpRatingTypeId || seasonalDiscountDbVesion.HireGroupId != item.HireGroupId ||
                                 seasonalDiscountDbVesion.VehicleCategoryId != item.VehicleCategoryId || seasonalDiscountDbVesion.VehicleMakeId != item.VehicleMakeId ||
                                seasonalDiscountDbVesion.VehicleModelId != item.VehicleModelId || seasonalDiscountDbVesion.ModelYear != item.ModelYear ||
                                seasonalDiscountDbVesion.SeasonalDiscountStartDt != item.SeasonalDiscountStartDt || seasonalDiscountDbVesion.SeasonalDiscountEndDt != item.SeasonalDiscountEndDt ||
                                // ReSharper disable once CompareOfFloatsByEqualityOperator
                                seasonalDiscountDbVesion.DiscountPerc != item.DiscountPerc)
                            {
                                item.IsActive = true;
                                item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                                item.RecLastUpdatedBy =
                                    item.RecCreatedBy = seasonalDiscountMainRepository.LoggedInUserIdentity;
                                item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                                item.RowVersion = 0;
                                item.SeasonalDiscountMainId = seasonalDiscountMain.SeasonalDiscountMainId;
                                item.RevisionNumber = seasonalDiscountDbVesion.RevisionNumber + 1;
                                item.SeasonalDiscountId = 0;
                                item.UserDomainKey = seasonalDiscountMainRepository.UserDomainKey;
                                seasonalDiscountRepository.Add(item);
                                seasonalDiscountRepository.SaveChanges();
                                seasonalDiscountDbVesion.ChildSeasonalDiscountId = item.SeasonalDiscountMainId;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add Seasonal Discount
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        private void AddSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain)
        {
            //Validate Chauffer Charge Main
            //SeasonalDiscountValidation(chaufferChargeMain, true);
            seasonalDiscountMain.IsActive = true;
            seasonalDiscountMain.IsDeleted =
                seasonalDiscountMain.IsPrivate = seasonalDiscountMain.IsReadOnly = false;
            seasonalDiscountMain.RecLastUpdatedBy =
                seasonalDiscountMain.RecCreatedBy = seasonalDiscountMainRepository.LoggedInUserIdentity;
            seasonalDiscountMain.RecCreatedDt = seasonalDiscountMain.RecLastUpdatedDt = DateTime.Now;
            seasonalDiscountMain.RowVersion = 0;
            seasonalDiscountMain.UserDomainKey = seasonalDiscountMainRepository.UserDomainKey;

            if (seasonalDiscountMain.SeasonalDiscounts != null)
            {
                foreach (var item in seasonalDiscountMain.SeasonalDiscounts)
                {
                    item.IsActive = true;
                    item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                    item.RecLastUpdatedBy = item.RecCreatedBy = seasonalDiscountMainRepository.LoggedInUserIdentity;
                    item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                    item.RowVersion = 0;
                    item.RevisionNumber = 0;
                    item.UserDomainKey = seasonalDiscountMainRepository.UserDomainKey;
                }
            }
            seasonalDiscountMainRepository.Add(seasonalDiscountMain);
        }

        /// <summary>
        /// Delete Seasonal Discount Main
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        public void DeleteSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain)
        {
            seasonalDiscountMainRepository.Delete(seasonalDiscountMain);
            seasonalDiscountMainRepository.SaveChanges();
        }

        /// <summary>
        /// Find Seasonal Discount Main By Id
        /// </summary>
        /// <param name="seasonalDiscountMainId"></param>
        /// <returns></returns>
        public SeasonalDiscountMain FindById(long seasonalDiscountMainId)
        {
            return seasonalDiscountMainRepository.Find(seasonalDiscountMainId);
        }

        /// <summary>
        /// Get Seasonal Discount By Seasonal Discount Main Id
        /// </summary>
        /// <param name="seasonalDiscountMainId"></param>
        /// <returns></returns>
        public IEnumerable<SeasonalDiscount> GetSeasonalDiscountsBySeasonalDiscountMainId(long seasonalDiscountMainId)
        {
            return seasonalDiscountRepository.GetSeasonalDiscountsBySeasonalDiscountMainId(seasonalDiscountMainId);
        }

        #endregion
    }
}
