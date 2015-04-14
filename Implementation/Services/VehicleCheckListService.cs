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
    /// Vehicle CheckList Service
    /// </summary>
    public class VehicleCheckListService : IVehicleCheckListService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IVehicleCheckListRepository vehicleCheckListRepository;
        private readonly IVehicleCheckListItemRepository vehicleCheckListItemRepository;
        private readonly IRaVehicleCheckListRepository raVehicleCheckListRepository;

        /// <summary>
        /// Set Vehicle CheckList Properties while adding new instance
        /// </summary>
        private void SetVehicleCheckListProperties(VehicleCheckList vehicleCheckList, VehicleCheckList dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = vehicleCheckListRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = vehicleCheckListRepository.UserDomainKey;
            dbVersion.VehicleCheckListCode = vehicleCheckList.VehicleCheckListCode;
            dbVersion.VehicleCheckListName = vehicleCheckList.VehicleCheckListName;
            dbVersion.VehicleCheckListDescription = vehicleCheckList.VehicleCheckListDescription;
            dbVersion.IsInterior = vehicleCheckList.IsInterior;
          
        }

        /// <summary>
        /// Update Vehicle CheckList Properties while updating the instance
        /// </summary>
        private void UpdateVehicleCheckListProperties(VehicleCheckList vehicleCheckList, VehicleCheckList dbVersion)
        {
            dbVersion.RecLastUpdatedBy = vehicleCheckListRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.VehicleCheckListCode = vehicleCheckList.VehicleCheckListCode;
            dbVersion.VehicleCheckListName = vehicleCheckList.VehicleCheckListName;
            dbVersion.VehicleCheckListDescription = vehicleCheckList.VehicleCheckListDescription;
            dbVersion.IsInterior = vehicleCheckList.IsInterior;
        }

        /// <summary>
        /// Check vehicle CheckList association with other entites before deletion
        /// </summary>
        private void CheckVehicleCheckListAssociations(long vehicleCheckListId)
        {
            // Ra VehicleCheck List - Vehicle CheckList association checking
            if (raVehicleCheckListRepository.IsRaVehicleCheckListAssociatedWithVehicleCheckList(vehicleCheckListId))
                throw new CaresException(Resources.FleetPool.VehicleCheckList.VehicleCheckListIsAssociatedWithRAvehicleCheckListError); 

            // Vehicle Check List Item -  Vehicle CheckList association checking
            if (vehicleCheckListItemRepository.IsVehicleCheckListItemAssociatedWithVehicleCheckList(vehicleCheckListId))
                throw new CaresException(Resources.FleetPool.VehicleCheckList.VehicleCheckListIsAssociatedWithCheckListItemError);
        }


        #endregion
        #region Constructor
        /// <summary>
        ///  Vehicle CheckList Constructor
        /// </summary>
        public VehicleCheckListService(IVehicleCheckListRepository vehicleCheckListRepository, IVehicleCheckListItemRepository vehicleCheckListItemRepository,
           IRaVehicleCheckListRepository raVehicleCheckListRepository)
        {
            this.vehicleCheckListRepository = vehicleCheckListRepository;
            this.vehicleCheckListItemRepository = vehicleCheckListItemRepository;
            this.raVehicleCheckListRepository = raVehicleCheckListRepository;
        }

        #endregion
        #region Public

          /// <summary>
        /// Delete Vehicle CheckList
        /// </summary>
        public void DeleteVehicleCheckList(long vehicleCheckListId)
        {
            VehicleCheckList dbversion = vehicleCheckListRepository.Find(vehicleCheckListId);
            CheckVehicleCheckListAssociations(vehicleCheckListId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.FleetPool.VehicleCheckList.VehicleCheckListNotFoundInDatabase));
                }
            vehicleCheckListRepository.Delete(dbversion);
            vehicleCheckListRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Vehicle CheckList
        /// </summary>
        public VehicleCheckListSearchRequestResponse SearchVehicleCheckList(VehicleCheckListSearchRequest request)
        {
            int rowCount;
            return new VehicleCheckListSearchRequestResponse
            {
                VehicleCheckLists = vehicleCheckListRepository.SearchVehicleCheckList(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Add / Update Vehicle CheckList
        /// </summary>
        public VehicleCheckList AddUpdateVehicleCheckList(VehicleCheckList vehicleCheckList)
        {
            VehicleCheckList dbVersion = vehicleCheckListRepository.Find(vehicleCheckList.VehicleCheckListId);

            if (vehicleCheckListRepository.DoesVehicleCheckListCodeExist(vehicleCheckList))
             throw new CaresException(Resources.FleetPool.VehicleCheckList.VehicleCheckListCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateVehicleCheckListProperties(vehicleCheckList, dbVersion);
                    vehicleCheckListRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new VehicleCheckList();
                    SetVehicleCheckListProperties(vehicleCheckList, dbVersion);
                    vehicleCheckListRepository.Add(dbVersion);
                }
                vehicleCheckListRepository.SaveChanges();
                return vehicleCheckListRepository.Find(dbVersion.VehicleCheckListId);
        }

        /// <summary>
        /// Get All For Vehicle 
        /// </summary>
        public IEnumerable<VehicleCheckList> GetForVehicle(long vehicleId)
        {
            return vehicleCheckListItemRepository.GetByVehicleId(vehicleId);
        }


        /// <summary>
        /// Load All Vehicle CheckList
        /// </summary>
        public IEnumerable<VehicleCheckList> LoadAll()
        {
            return vehicleCheckListRepository.GetAll();
        }
        #endregion
    }
}
