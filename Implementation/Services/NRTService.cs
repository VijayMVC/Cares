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
        private readonly IVehicleReservationRepository vehicleReservationRepository;
        private readonly IChaufferReservationRepository chaufferReservationRepository;
        private readonly INrtChargeRepository nrtChargeRepository;
        private readonly INrtDriverRepository nrtDriverRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public NRTService(IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,
            INrtTypeRepository nrtTypeRepository, IVehicleStatusRepository vehicleStatusRepository, IAdditionalChargeRepository additionalChargeRepository,
            IVehicleRepository vehicleRepository, INrtMainRepository nrtMainRepository, INrtVehicleRepository nrtVehicleRepository,
            IRaStatusRepository raStatusRepository, IVehicleReservationRepository vehicleReservationRepository,
            IChaufferReservationRepository chaufferReservationRepository, INrtChargeRepository nrtChargeRepository, INrtDriverRepository nrtDriverRepository)
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
            this.vehicleReservationRepository = vehicleReservationRepository;
            this.chaufferReservationRepository = chaufferReservationRepository;
            this.nrtChargeRepository = nrtChargeRepository;
            this.nrtDriverRepository = nrtDriverRepository;
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
            RaStatus raStatus;
            if (nrtVehicle.NrtMain.NrtStatusId == 2)
            {
                raStatus = raStatusRepository.FindByStatusKey(2);
            }
            else
            {
                raStatus = raStatusRepository.FindByStatusKey(1);
            }

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
                //Vehicle Reservation
                VehicleReservation vehicleReservation = new VehicleReservation();
                vehicleReservation.IsActive = true;
                vehicleReservation.IsDeleted =
                    vehicleReservation.IsPrivate = vehicleReservation.IsReadOnly = false;
                vehicleReservation.RecLastUpdatedBy =
                   vehicleReservation.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                vehicleReservation.RecCreatedDt = vehicleReservation.RecLastUpdatedDt = DateTime.Now;
                vehicleReservation.RowVersion = 0;
                vehicleReservation.UserDomainKey = nrtMainRepository.UserDomainKey;
                vehicleReservation.VehicleId = nrtVehicle.VehicleId;
                vehicleReservation.StartDtTime = nrtVehicle.NrtMain.StartDtTime;
                vehicleReservation.EndDtTime = nrtVehicle.NrtMain.EndDtTime;
                vehicleReservation.NrtMainId = nrtVehicle.NrtMain.NrtMainId;
                vehicleReservationRepository.Add(vehicleReservation);
                vehicleReservationRepository.SaveChanges();


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

                        //Chauffer Reservation
                        ChaufferReservation chaufferReservation = new ChaufferReservation();
                        chaufferReservation.IsActive = true;
                        chaufferReservation.IsDeleted =
                            chaufferReservation.IsPrivate = chaufferReservation.IsReadOnly = false;
                        chaufferReservation.RecLastUpdatedBy =
                        chaufferReservation.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                        chaufferReservation.RecCreatedDt = chaufferReservation.RecLastUpdatedDt = DateTime.Now;
                        chaufferReservation.RowVersion = 0;
                        chaufferReservation.UserDomainKey = nrtMainRepository.UserDomainKey;
                        chaufferReservation.ChaufferId = (item.ChaufferId ?? 0);
                        chaufferReservation.StartDtTime = nrtVehicle.NrtMain.StartDtTime;
                        chaufferReservation.EndDtTime = nrtVehicle.NrtMain.EndDtTime;
                        chaufferReservation.NrtMainId = nrtVehicle.NrtMain.NrtMainId;
                        chaufferReservationRepository.Add(chaufferReservation);
                        chaufferReservationRepository.SaveChanges();
                    }
                }

                //NRT Vehicle movements
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
            else
            {
                //NrtVehicle nrtVehicleDbVersion = nrtVehicleRepository.Find(nrtMainDbVersion.NrtMainId);


                nrtMainDbVersion.CloseLocationId = nrtVehicle.NrtMain.CloseLocationId;
                nrtMainDbVersion.EndDtTime = nrtVehicle.NrtMain.EndDtTime;
                nrtMainDbVersion.NrtStatusId = raStatus.RaStatusId;
                //Vehicle Reservation
                if (nrtMainDbVersion.VehicleReservations != null)
                {
                    foreach (var item in nrtMainDbVersion.VehicleReservations)
                    {
                        item.EndDtTime = nrtVehicle.NrtMain.EndDtTime;
                    }
                }

                if (nrtMainDbVersion.NrtVehicles != null)
                {
                    foreach (var nrtVehicleDbVersion in nrtMainDbVersion.NrtVehicles)
                    {
                        #region NRT Drivers
                        if (nrtVehicle.NrtDrivers != null)
                        {
                            foreach (var item in nrtVehicle.NrtDrivers)
                            {
                                if (
                                    nrtVehicleDbVersion.NrtDrivers.All(
                                        x =>
                                            x.NrtDriverId != item.NrtDriverId ||
                                            item.NrtDriverId == 0))
                                {
                                    item.IsActive = true;
                                    item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                                    item.RecLastUpdatedBy = item.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                                    item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                                    item.RowVersion = 0;
                                    item.UserDomainKey = nrtMainRepository.UserDomainKey;
                                    item.NrtVehicleId = nrtVehicle.NrtVehicleId;
                                    nrtVehicleDbVersion.NrtDrivers.Add(item);

                                    //Chauffer Reservation
                                    ChaufferReservation chaufferReservation = new ChaufferReservation();
                                    chaufferReservation.IsActive = true;
                                    chaufferReservation.IsDeleted =
                                        chaufferReservation.IsPrivate = chaufferReservation.IsReadOnly = false;
                                    chaufferReservation.RecLastUpdatedBy =
                                    chaufferReservation.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                                    chaufferReservation.RecCreatedDt = chaufferReservation.RecLastUpdatedDt = DateTime.Now;
                                    chaufferReservation.RowVersion = 0;
                                    chaufferReservation.UserDomainKey = nrtMainRepository.UserDomainKey;
                                    chaufferReservation.ChaufferId = (item.ChaufferId ?? 0);
                                    chaufferReservation.StartDtTime = nrtVehicle.NrtMain.StartDtTime;
                                    chaufferReservation.EndDtTime = nrtVehicle.NrtMain.EndDtTime;
                                    chaufferReservation.NrtMainId = nrtVehicle.NrtMain.NrtMainId;
                                    chaufferReservationRepository.Add(chaufferReservation);
                                    chaufferReservationRepository.SaveChanges();
                                }
                            }
                        }

                        //find missing items
                        List<NrtDriver> missingNrtDriverItems = new List<NrtDriver>();
                        foreach (NrtDriver dbversionNrtDriverItem in nrtVehicleDbVersion.NrtDrivers)
                        {
                            if (nrtVehicle.NrtDrivers != null && nrtVehicle.NrtDrivers.All(x => x.NrtDriverId != dbversionNrtDriverItem.NrtDriverId))
                            {
                                missingNrtDriverItems.Add(dbversionNrtDriverItem);
                            }
                            if (nrtVehicle.NrtDrivers == null)
                            {
                                missingNrtDriverItems.Add(dbversionNrtDriverItem);
                            }
                        }
                        //remove missing items
                        foreach (NrtDriver missingNrtDriverItem in missingNrtDriverItems)
                        {
                            NrtDriver dbVersionMissingItem = nrtVehicleDbVersion.NrtDrivers.First(x => x.NrtDriverId == missingNrtDriverItem.NrtDriverId);
                            if (dbVersionMissingItem.NrtDriverId > 0)
                            {
                                nrtVehicleDbVersion.NrtDrivers.Remove(dbVersionMissingItem);
                                nrtDriverRepository.Delete(dbVersionMissingItem);
                                nrtDriverRepository.SaveChanges();
                            }
                        }
                        #endregion

                        #region NRT Charges
                        if (nrtVehicle.NrtCharges != null)
                        {
                            foreach (var item in nrtVehicle.NrtCharges)
                            {
                                if (
                                    nrtVehicleDbVersion.NrtCharges.All(
                                        x =>
                                            x.NrtChargeId != item.NrtChargeId ||
                                            item.NrtChargeId == 0))
                                {
                                    item.IsActive = true;
                                    item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                                    item.RecLastUpdatedBy = item.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                                    item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                                    item.RowVersion = 0;
                                    item.UserDomainKey = nrtMainRepository.UserDomainKey;
                                    item.NrtVehicleId = nrtVehicle.NrtVehicleId;

                                    nrtVehicleDbVersion.NrtCharges.Add(item);
                                }
                            }
                        }

                        //find missing items
                        List<NrtCharge> missingNrtChargeItems = new List<NrtCharge>();
                        foreach (NrtCharge dbversionNrtChargeItem in nrtVehicleDbVersion.NrtCharges)
                        {
                            if (nrtVehicle.NrtCharges != null && nrtVehicle.NrtCharges.All(x => x.NrtChargeId != dbversionNrtChargeItem.NrtChargeId))
                            {
                                missingNrtChargeItems.Add(dbversionNrtChargeItem);
                            }
                            if (nrtVehicle.NrtCharges == null)
                            {
                                missingNrtChargeItems.Add(dbversionNrtChargeItem);
                            }
                        }
                        //remove missing items
                        foreach (NrtCharge missingNrtChargeItem in missingNrtChargeItems)
                        {
                            NrtCharge dbVersionMissingItem = nrtVehicleDbVersion.NrtCharges.First(x => x.NrtChargeId == missingNrtChargeItem.NrtChargeId);
                            if (dbVersionMissingItem.NrtChargeId > 0)
                            {
                                nrtVehicleDbVersion.NrtCharges.Remove(dbVersionMissingItem);
                                nrtChargeRepository.Delete(dbVersionMissingItem);
                                nrtChargeRepository.SaveChanges();
                            }
                        }
                        #endregion

                        //NRT Vehicle movements
                        if (nrtVehicleDbVersion.NrtVehicleMovements != null)
                        {
                            foreach (var vMovement in nrtVehicle.NrtVehicleMovements)
                            {
                                if (vMovement.MovementStatus)
                                {
                                    bool flag = false;
                                    foreach (var item in nrtVehicleDbVersion.NrtVehicleMovements)
                                    {
                                        if (item.MovementStatus)
                                        {
                                            flag = true;
                                            item.DtTime = vMovement.DtTime;
                                            item.FuelLevel = vMovement.FuelLevel;
                                            item.Odometer = vMovement.Odometer;
                                            item.OperationsWorkPlaceId = vMovement.OperationsWorkPlaceId;
                                            item.VehicleStatusId = vMovement.VehicleStatusId;
                                            item.VehicleCondition = "0011111";
                                        }
                                    }
                                    //in case return vehicle new add
                                    if (!flag)
                                    {
                                        vMovement.IsActive = true;
                                        vMovement.IsDeleted = vMovement.IsPrivate = vMovement.IsReadOnly = false;
                                        vMovement.RecLastUpdatedBy = vMovement.RecCreatedBy = nrtMainRepository.LoggedInUserIdentity;
                                        vMovement.RecCreatedDt = vMovement.RecLastUpdatedDt = DateTime.Now;
                                        vMovement.RowVersion = 0;
                                        vMovement.UserDomainKey = nrtMainRepository.UserDomainKey;
                                        vMovement.NrtVehicleId = nrtVehicle.NrtVehicleId;
                                        vMovement.VehicleCondition = "0011111";
                                        nrtVehicleDbVersion.NrtVehicleMovements.Add(vMovement);
                                    }
                                }
                            }
                        }
                    }
                    nrtMainRepository.SaveChanges();
                }
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
