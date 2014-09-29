using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.ExceptionHandling;
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

            return null;
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
