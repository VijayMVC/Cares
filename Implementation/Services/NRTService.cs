using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Non Revenue Ticket Service
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class NRTService : INRTService
    {
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly INrtTypeRepository nrtTypeRepository;
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly IAdditionalChargeRepository additionalChargeRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly INrtMainRepository nrtMainRepository;
        private readonly INrtVehicleRepository nrtVehicleRepository;
        private readonly IRaStatusRepository raStatusRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public NRTService(IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            INrtTypeRepository nrtTypeRepository, IVehicleStatusRepository vehicleStatusRepository, IAdditionalChargeRepository additionalChargeRepository,
            IVehicleRepository vehicleRepository, INrtMainRepository nrtMainRepository, INrtVehicleRepository nrtVehicleRepository,
            IRaStatusRepository raStatusRepository)
        {
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.nrtTypeRepository = nrtTypeRepository;
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.additionalChargeRepository = additionalChargeRepository;
            this.vehicleRepository = vehicleRepository;
            this.nrtMainRepository = nrtMainRepository;
            this.nrtVehicleRepository = nrtVehicleRepository;
            this.raStatusRepository = raStatusRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Non Revenue Ticket Base data
        /// </summary>
        public NRTBaseResponse GetBaseData()
        {
            return new NRTBaseResponse
            {
                Operations = operationRepository.GetAll(),
                Locations = operationsWorkPlaceRepository.GetAll(),
                NRTTypes = nrtTypeRepository.GetAll(),
                VehicleStatuses = vehicleStatusRepository.GetAll(),
            };
        }

        /// <summary>
        /// Get Additional Charge For NRT
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public IEnumerable<AdditionalChargeForNrt> AdditionalChargeForNrt(DateTime startDt, long vehicleId)
        {
            Vehicle vehicle = vehicleRepository.Find(vehicleId);
            return additionalChargeRepository.AdditionalChargeForNrt(startDt, vehicle);
        }

        /// <summary>
        /// Save NRT 
        /// </summary>
        /// <param name="nrtVehicle"></param>
        /// <returns></returns>
        public long SaveNrt(NrtVehicle nrtVehicle)
        {
            NrtMain nrtMainDbVersion = nrtMainRepository.Find(nrtVehicle.NrtMainId);
            RaStatus raStatus = raStatusRepository.FindByStatusKey(1);
            if (nrtMainDbVersion == null)
            {
                //NRT Main
                nrtVehicle.NrtMain.IsActive = true;
                nrtVehicle.NrtMain.IsDeleted =
                    nrtVehicle.NrtMain.IsPrivate = nrtVehicle.NrtMain.IsReadOnly = false;
                nrtVehicle.NrtMain.RecLastUpdatedBy =
                    nrtVehicle.NrtMain.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                nrtVehicle.NrtMain.RecCreatedDt = nrtVehicle.NrtMain.RecLastUpdatedDt = DateTime.Now;
                nrtVehicle.NrtMain.RowVersion = 0;
                nrtVehicle.NrtMain.UserDomainKey = nrtMainRepository.UserDomainKey;
                nrtVehicle.NrtMain.NrtStatusId = raStatus != null ? raStatus.RaStatusId : raStatus.RaStatusId;
                nrtMainRepository.Add(nrtVehicle.NrtMain);
                nrtMainRepository.SaveChanges();

                //NRT vehicle
                nrtVehicle.IsActive = true;
                nrtVehicle.IsDeleted =
                    nrtVehicle.IsPrivate = nrtVehicle.IsReadOnly = false;
                nrtVehicle.RecLastUpdatedBy =
                   nrtVehicle.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                nrtVehicle.RecCreatedDt = nrtVehicle.RecLastUpdatedDt = DateTime.Now;
                nrtVehicle.RowVersion = 0;
                nrtVehicle.UserDomainKey = nrtMainRepository.UserDomainKey;
                nrtVehicle.NrtVehicleId = nrtVehicle.VehicleId;
                nrtVehicle.NrtMainId = nrtVehicle.NrtMain.NrtMainId;

                //NRT Drivers
                if (nrtVehicle.NrtDrivers != null)
                {
                    foreach (var item in nrtVehicle.NrtDrivers)
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy = item.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.UserDomainKey = nrtMainRepository.UserDomainKey;
                        item.NrtVehicleId = nrtVehicle.NrtVehicleId;
                    }
                }

                //NRT Drivers
                if (nrtVehicle.NrtVehicleMovements != null)
                {
                    foreach (var item in nrtVehicle.NrtVehicleMovements)
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy = item.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.UserDomainKey = nrtMainRepository.UserDomainKey;
                        item.NrtVehicleId = nrtVehicle.NrtVehicleId;
                        item.VehicleCondition = "0011111";
                    }
                }

                //NRT Charges
                if (nrtVehicle.NrtCharges != null)
                {
                    foreach (var item in nrtVehicle.NrtCharges)
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy = item.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.UserDomainKey = nrtMainRepository.UserDomainKey;
                        item.NrtVehicleId = nrtVehicle.NrtVehicleId;
                    }
                }
                nrtVehicleRepository.Add(nrtVehicle);
                nrtVehicleRepository.SaveChanges();
            }

            return nrtVehicle.NrtMain.NrtMainId;
        }

        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="nrtMainId"></param>
        /// <returns></returns>
        public NrtMain FindById(long nrtMainId)
        {
            return nrtMainRepository.Find(nrtMainId);
        }
        #endregion
    }
}
