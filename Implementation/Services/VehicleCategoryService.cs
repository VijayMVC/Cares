using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Vehicle Category Service
    /// </summary>
    public class VehicleCategoryService : IVehicleCategoryService
    {
        #region Private
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly ISeasonalDiscountRepository seasonalDiscountRepository;
        private readonly IStandardDiscountRepository standardDiscountRepository;
        private readonly IVehicleRepository vehicleRepository;

        /// <summary>
        /// Set newly created Vehicle Category object Properties in case of adding
        /// </summary>
        private void SetVehicleCategoryProperties(VehicleCategory vehicleCategory, VehicleCategory dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = vehicleCategoryRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.VehicleCategoryCode = vehicleCategory.VehicleCategoryCode;
            dbVersion.VehicleCategoryName = vehicleCategory.VehicleCategoryName;
            dbVersion.VehicleCategoryDescription = vehicleCategory.VehicleCategoryDescription;
            dbVersion.UserDomainKey = vehicleCategoryRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Vehicle Category object Properties in case of updation
        /// </summary>
        protected void UpdateVehicleCategoryPropertie(VehicleCategory vehicleCategory, VehicleCategory dbVersion)
        {
            dbVersion.RecLastUpdatedBy = vehicleCategoryRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.VehicleCategoryCode = vehicleCategory.VehicleCategoryCode;
            dbVersion.VehicleCategoryName = vehicleCategory.VehicleCategoryName;
            dbVersion.VehicleCategoryDescription = vehicleCategory.VehicleCategoryDescription;
        }

        /// <summary>
        /// Validation check for deletion
        /// </summary>
        private void ValidateBeforeDeletion(long vehicleCategoryId)
        {
            // Association check of HireGroup Detail and Vehicle Category
            if (hireGroupDetailRepository.IsHireGroupDetailAssociatedWithVehicleCategory(vehicleCategoryId))
                throw new CaresException(Resources.FleetPool.VehicleCategory.VehicleCategoryIsAssociatedWithHireGroupDetailError);

            // Association check of Seasonal Discount and Vehicle Category
            if (seasonalDiscountRepository.IsSeasonalDiscountAssociatedWithVehicleCategory(vehicleCategoryId))
                throw new CaresException(Resources.FleetPool.VehicleCategory.VehicleCategoryIsAssociatedWithSessionalDiscountError);

            // Association check of Standard Discount and vehicle Category 
            if (standardDiscountRepository.IsStandardDiscountAssociatedWithVehicleCategory(vehicleCategoryId))
                throw new CaresException(Resources.FleetPool.VehicleCategory.VehicleCategoryIsAssociatedWithStandardDiscountError);

            // Association check b/n vehicle and vehicle Category
            if (vehicleRepository.IsVehicleCategoryAssociatedWithVehicle(vehicleCategoryId))
                throw new CaresException(Resources.FleetPool.VehicleCategory.VehicleCategoryIsAssociatedWithVehicleError);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleCategoryService(IVehicleCategoryRepository vehicleCategoryRepository, IHireGroupDetailRepository hireGroupDetailRepository,
            ISeasonalDiscountRepository seasonalDiscountRepository, IStandardDiscountRepository standardDiscountRepository, IVehicleRepository vehicleRepository)
        {
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.seasonalDiscountRepository = seasonalDiscountRepository;
            this.standardDiscountRepository = standardDiscountRepository;
            this.vehicleRepository = vehicleRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Vehicle Categories
        /// </summary>
        public IEnumerable<VehicleCategory> LoadAll()
        {
            return vehicleCategoryRepository.GetAll();
        }


        /// <summary>
        /// Search Vehicle Category
        /// </summary>
        public VehicleCategorySearchRequestResponse SearchVehicleCategory(VehicleCategorySearchRequest request)
        {
            int rowCount;
            return new VehicleCategorySearchRequestResponse
            {
                VehicleCategories = vehicleCategoryRepository.SearchVehicleCategory(request, out rowCount),
                TotalCount = rowCount
            };
        }


         /// <summary>
        /// Delete Vehicle Category by id
        /// </summary>
        public void DeleteVehicleCategory(long vehicleCategoryId)
        {
            VehicleCategory dbversion = vehicleCategoryRepository.Find((int)vehicleCategoryId);
            ValidateBeforeDeletion(vehicleCategoryId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Vehicle Category with Id {0} not found!", vehicleCategoryId));
            }
            vehicleCategoryRepository.Delete(dbversion);
            vehicleCategoryRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Vehicle Category
        /// </summary>
        public VehicleCategory SaveVehicleCategory(VehicleCategory vehicleCategory)
        {
            VehicleCategory dbVersion = vehicleCategoryRepository.Find(vehicleCategory.VehicleCategoryId);
            //Code Duplication Check
            if (vehicleCategoryRepository.VehicleCategoryCodeDuplicationCheck(vehicleCategory))
                throw new CaresException(Resources.FleetPool.VehicleCategory.VehicleCategoryCodeDuplicationError); 

            //UPDATE
            if (dbVersion != null) 
            {
                UpdateVehicleCategoryPropertie(vehicleCategory, dbVersion);
                vehicleCategoryRepository.Update(dbVersion);
            } //ADD
            else
            {
                dbVersion = new VehicleCategory();
                SetVehicleCategoryProperties(vehicleCategory, dbVersion);
                vehicleCategoryRepository.Add(dbVersion);
            }
            vehicleCategoryRepository.SaveChanges();
            return vehicleCategoryRepository.Find(dbVersion.VehicleCategoryId);
        }
        #endregion
    }
}