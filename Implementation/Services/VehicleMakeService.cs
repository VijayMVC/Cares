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
    /// Vehicle Make Service
    /// </summary>
    public class VehicleMakeService : IVehicleMakeService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly ISeasonalDiscountRepository seasonalDiscountRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IStandardDiscountRepository standardDiscountRepository;

       
       
        /// <summary>
        /// Set Vehicle Make Properties while adding new instance
        /// </summary>
        private void SetVehicleMakeProperties(VehicleMake vehicleMake, VehicleMake dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = vehicleMakeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = vehicleMakeRepository.UserDomainKey;
            dbVersion.VehicleMakeCode = vehicleMake.VehicleMakeCode;
            dbVersion.VehicleMakeName = vehicleMake.VehicleMakeName;
            dbVersion.VehicleMakeDescription = vehicleMake.VehicleMakeDescription;
        }

        /// <summary>
        /// Update Vehicle Make Properties while updating the instance
        /// </summary>
        private void UpdateVehicleMakeProperties(VehicleMake vehicleMake, VehicleMake dbVersion)
        {
            dbVersion.RecLastUpdatedBy = vehicleMakeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.VehicleMakeCode = vehicleMake.VehicleMakeCode;
            dbVersion.VehicleMakeName = vehicleMake.VehicleMakeName;
            dbVersion.VehicleMakeDescription = vehicleMake.VehicleMakeDescription;
        }

        /// <summary>
        /// Check Vehicle Make association with other entites before deletion
        /// </summary>
        private void CheckVehicleMakeAssociations(long vehicleMakeId)
        {
            // Association check b/n vehicle and vehicle make
            if (vehicleRepository.IsVehicleMakeAssociatedWithVehicle(vehicleMakeId))
                throw new CaresException(Resources.FleetPool.VehicleMake.VehicleMakeIsAssociatedWithVehicleError);

            // Association check of Seasonal Discount and Vehicle Make
            if (seasonalDiscountRepository.IsSeasonalDiscountAssociatedWithVehicleMake(vehicleMakeId))
                throw new CaresException(Resources.FleetPool.VehicleMake.VehicleMakeIsAssociatedWithSessionalDiscountError);

            // Association check of HireGroup Detail and Vehicle Make
            if (hireGroupDetailRepository.IsHireGroupDetailAssociatedWithVehicleMake(vehicleMakeId))
                throw new CaresException(Resources.FleetPool.VehicleMake.VehicleMakeIsAssociatedWithHireGroupDetailError);

            //  Association check of Standard Discount and vehicle make
            if (standardDiscountRepository.IsStandardDiscountAssociatedWithVehicleMake(vehicleMakeId))
                throw new CaresException(Resources.FleetPool.VehicleMake.VehicleMakeIsAssociatedWithStandardDiscountError);
        }


        #endregion
        #region Constructor
        /// <summary>
        ///  vehicle Make Constructor
        /// </summary>
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IVehicleRepository vehicleRepository, ISeasonalDiscountRepository seasonalDiscountRepository,
            IHireGroupDetailRepository hireGroupDetailRepository, IStandardDiscountRepository standardDiscountRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleRepository = vehicleRepository;
            this.seasonalDiscountRepository = seasonalDiscountRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.standardDiscountRepository = standardDiscountRepository;
        }

        #endregion
        #region Public

      

      /// <summary>
        /// Delete Vehicle Make
        /// </summary>
       public void DeleteVehicleMake(long vehicleMakeId)
        {
            VehicleMake dbversion = vehicleMakeRepository.Find(vehicleMakeId);
            CheckVehicleMakeAssociations(vehicleMakeId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Vehicle Make with Id {0} not found!", vehicleMakeId));
                }
            vehicleMakeRepository.Delete(dbversion);
            vehicleMakeRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Vehicle Make
        /// </summary>
        public VehicleMakeSearchRequestResponse SearchVehicleMake(VehicleMakeSearchRequest request)
        {
            int rowCount;
            return new VehicleMakeSearchRequestResponse
            {
                VehicleMakes = vehicleMakeRepository.SearchVehicleMake(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Add / Update Vehicle Make
        /// </summary>
        public VehicleMake AddUpdateVehicleMake(VehicleMake vehicleMake)
        {
            VehicleMake dbVersion = vehicleMakeRepository.Find(vehicleMake.VehicleMakeId);

            if (vehicleMakeRepository.VehicleMakeCodeDuplicationCheck(vehicleMake))            
            throw new CaresException(Resources.FleetPool.VehicleMake.VehicleMakeCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateVehicleMakeProperties(vehicleMake, dbVersion);
                    vehicleMakeRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new VehicleMake();
                    SetVehicleMakeProperties(vehicleMake, dbVersion);
                    vehicleMakeRepository.Add(dbVersion);
                }
                vehicleMakeRepository.SaveChanges();
                // To Load the proprties
                return vehicleMakeRepository.Find(dbVersion.VehicleMakeId);
        }

       
        /// <summary>
        /// Load All Vehicle Makes
        /// </summary>
        public IEnumerable<VehicleMake> LoadAll()
        {
            return vehicleMakeRepository.GetAll();
        }
        #endregion
    }
}
