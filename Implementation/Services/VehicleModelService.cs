using System;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Implementation.Services
{
    /// <summary>
    /// Vehicle Model Service
    /// </summary>
    public class VehicleModelService : IVehicleModelService
    {   
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly ISeasonalDiscountRepository seasonalDiscountRepository;
        private readonly IStandardDiscountRepository standardDiscountRepository;
        private readonly IVehicleRepository vehicleRepository;


        /// <summary>
        /// Set Vehicle Model Properties while adding new instance
        /// </summary>
        private void SetCompanyProperties(VehicleModel vehicleModel, VehicleModel dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = vehicleModelRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = vehicleModelRepository.UserDomainKey;
            dbVersion.VehicleModelCode = vehicleModel.VehicleModelCode;
            dbVersion.VehicleModelName = vehicleModel.VehicleModelName;
            dbVersion.VehicleModelDescription = vehicleModel.VehicleModelDescription;
        }

        /// <summary>
        /// Update Vehicle Model Properties while updating the instance
        /// </summary>
        private void UpdateCompanyProperties(VehicleModel vehicleModel, VehicleModel dbVersion)
        {
            dbVersion.RecLastUpdatedBy = vehicleModelRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.VehicleModelCode = vehicleModel.VehicleModelCode;
            dbVersion.VehicleModelName = vehicleModel.VehicleModelName;
            dbVersion.VehicleModelDescription = vehicleModel.VehicleModelDescription;
        }

        /// <summary>
        /// Check Vehicle Model association with other entites before deletion
        /// </summary>
        private void CheckVehicleModelAssociations(long vehicleModelId)
        {
            //  Association check of HireGroup Detail and Vehicle Model
            if (hireGroupDetailRepository.IsHireGroupDetailAssociatedWithVehicleModel(vehicleModelId))
                throw new CaresException(Resources.FleetPool.VehicleModel.VehicleModelIsAssociatedWithHireGroupDetailError);

            // Association check of Seasonal Discount and Vehicle Model
            if (seasonalDiscountRepository.IsSeasonalDiscountAssociatedWithVehicleModel(vehicleModelId))
                throw new CaresException(Resources.FleetPool.VehicleModel.VehicleModelIsAssociatedWithSessionalDiscountError);

            // Association check of Standard Discount and vehicle Model
            if (standardDiscountRepository.IsStandardDiscountAssociatedWithVehicleModel(vehicleModelId))
                throw new CaresException(Resources.FleetPool.VehicleModel.VehicleModelIsAssociatedWithStandardDiscountError);

            //Association check b/n vehicle and vehicle Model
            if (vehicleRepository.IsVehicleModelAssociatedWithVehicle(vehicleModelId))
                throw new CaresException(Resources.FleetPool.VehicleModel.VehicleModelIsAssociatedWithVehicleError);


        }


        #endregion
        #region Constructor

        /// <summary>
        ///  Vehicle Model Constructor
        /// </summary>
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IHireGroupDetailRepository hireGroupDetailRepository, ISeasonalDiscountRepository seasonalDiscountRepository,
           IStandardDiscountRepository standardDiscountRepository, IVehicleRepository vehicleRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.seasonalDiscountRepository = seasonalDiscountRepository;
            this.standardDiscountRepository = standardDiscountRepository;
            this.vehicleRepository = vehicleRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Delete Vehicle Model
        /// </summary>
        public void DeleteVehicleModel(long vehicleModelId)
        {
            VehicleModel dbversion = vehicleModelRepository.Find(vehicleModelId);
            CheckVehicleModelAssociations(vehicleModelId);
            if (dbversion == null)
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.FleetPool.VehicleModel.VehicleModelNotFoundInDatabase));
            vehicleModelRepository.Delete(dbversion);
            vehicleModelRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Vehicle Model
        /// </summary>
        public VehicleModelSearcgRequestResponse SearchVehicleModel(VehicleModelSearcgRequest request)
        {
            int rowCount;
            return new VehicleModelSearcgRequestResponse
            {
                VehicleModels = vehicleModelRepository.SearchVehicleModel(request, out rowCount),
                TotalCount = rowCount
            };
        }


      /// <summary>
        /// Add / Update Vehicle Model
        /// </summary>
        public VehicleModel AddUpdateVehicleModel(VehicleModel vehicleModel)
        {
            VehicleModel dbVersion = vehicleModelRepository.Find(vehicleModel.VehicleModelId);
            if (vehicleModelRepository.VehicleModelCodeDuplicationCheck(vehicleModel))
                throw new CaresException(Resources.FleetPool.VehicleModel.VehicleModelCodeDuplicationError);
            
                if (dbVersion != null)
                {
                    UpdateCompanyProperties(vehicleModel, dbVersion);
                    vehicleModelRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new VehicleModel();
                    SetCompanyProperties(vehicleModel, dbVersion);
                    vehicleModelRepository.Add(dbVersion);
                }

                vehicleModelRepository.SaveChanges();
                // To Load the proprties
                return vehicleModelRepository.Find(dbVersion.VehicleModelId);
            
        }

       
        /// <summary>
        /// Load All Vehicle Models
        /// </summary>
        public IEnumerable<VehicleModel> LoadAll()
        {
            return vehicleModelRepository.GetAll();
        }
        #endregion
    }
}
