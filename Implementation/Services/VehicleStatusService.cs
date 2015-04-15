using System;
using System.Collections.Generic;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Vehicle Status Service
    /// </summary>
    public class VehicleStatusService : IVehicleStatusService
    {
        #region Private
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly INrtTypeRepository nrtTypeRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IVehicleSubStatusRepository subStatusRepository;

        /// <summary>
        /// Check Association with other objects Before Deletion
        /// </summary>
        private  void CheckAssociationBeforeDeletion(long vehicleStatusId)
        {
            if (nrtTypeRepository.IsVehicleStatusAssociatedWithNrtType(vehicleStatusId))
                throw new CaresException(Resources.FleetPool.VehicleStatus.VehicleStatusIsAssociatedWithNRTTypeError);


            if (vehicleRepository.IsVehicleStatusAssociatedWithVehicle(vehicleStatusId))
                throw new CaresException(Resources.FleetPool.VehicleStatus.VehicleStatusIsAssociatedWithVehicleError);


            if (subStatusRepository.IsVehicleSubStatusAssociatedWithVehicleStatus(vehicleStatusId))
                throw new CaresException(Resources.FleetPool.VehicleStatus.VehicleStatusIsAssociatedWithVehicleSubStatusError);

        }

        /// <summary>
        /// Set Vehicle Status Properties while adding new instance
        /// </summary>
        private void SetVehicleStatusProperties(VehicleStatus vehicleStatus, VehicleStatus dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = vehicleStatusRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = vehicleStatusRepository.UserDomainKey;
            dbVersion.VehicleStatusCode = vehicleStatus.VehicleStatusCode;
            dbVersion.VehicleStatusName = vehicleStatus.VehicleStatusName;
            dbVersion.VehicleStatusDescription = vehicleStatus.VehicleStatusDescription;
        }

        /// <summary>
        /// Update Vehicle Status Properties while updating the instance
        /// </summary>
        private void UpdateVehicleStatusProperties(VehicleStatus vehicleStatus, VehicleStatus dbVersion)
        {
            dbVersion.RecLastUpdatedBy = vehicleStatusRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.VehicleStatusCode = vehicleStatus.VehicleStatusCode;
            dbVersion.VehicleStatusName = vehicleStatus.VehicleStatusName;
            dbVersion.VehicleStatusDescription = vehicleStatus.VehicleStatusDescription;
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Vehicle Status Constructor
        /// </summary>
        public VehicleStatusService(IVehicleStatusRepository vehicleStatusRepository, INrtTypeRepository nrtTypeRepository, IVehicleRepository vehicleRepository,
            IVehicleSubStatusRepository subStatusRepository)
        {
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.nrtTypeRepository = nrtTypeRepository;
            this.vehicleRepository = vehicleRepository;
            this.subStatusRepository = subStatusRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Search Vehicle Status
        /// </summary>
        public VehicleStatusSearchRequestResponse SearchVehicleStatus(VehicleStatusSearchRequest request)
        {
            int rowCount;
            return new VehicleStatusSearchRequestResponse
            {
                VehicleStatuses = vehicleStatusRepository.SearchVehicleStatus(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Delete Vehicle Status
        /// </summary>
        public void DeleteVehicleStatus(long vehicleStatusId)
        {
            VehicleStatus dbVersion = vehicleStatusRepository.Find(vehicleStatusId);
            CheckAssociationBeforeDeletion(vehicleStatusId);
            if (dbVersion == null)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.FleetPool.VehicleStatus.VehicleStatusNotFoundInDatabase));
            vehicleStatusRepository.Delete(dbVersion);
            vehicleStatusRepository.SaveChanges();
        }

      
        /// <summary>
        /// Load All Vehicle Statuses
        /// </summary>
        public IEnumerable<VehicleStatus> LoadAll()
        {
            return vehicleStatusRepository.GetAll();
        }

       
        /// <summary>
        /// Save or Update Vehicle Status
        /// </summary>
        public VehicleStatus SaveUpdateVehicleStatus(VehicleStatus vehicleStatus)
        {
            VehicleStatus dbVersion = vehicleStatusRepository.Find(vehicleStatus.VehicleStatusId);

            if (vehicleStatusRepository.VehicleStatusCodeDuplicationCheck(vehicleStatus))            
            throw new CaresException(Resources.FleetPool.VehicleStatus.VehicleStatusCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateVehicleStatusProperties(vehicleStatus, dbVersion);
                    vehicleStatusRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new VehicleStatus();
                    SetVehicleStatusProperties(vehicleStatus, dbVersion);
                    vehicleStatusRepository.Add(dbVersion);
                }
                vehicleStatusRepository.SaveChanges();
                // To Load the proprties
                return vehicleStatusRepository.Find(dbVersion.VehicleStatusId);
        }
        #endregion
    }
}