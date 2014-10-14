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
    /// Maintenece Type Group Service
    /// </summary>
    public class MainteneceTypeGroupService : IMainteneceTypeGroupService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IMainteneceTypeGroupRepository mainteneceTypeGroupRepository;
        private readonly IMaintenanceTypeRepository maintenanceTypeRepository;

        #region Private Methodes
        /// <summary>
        /// Set Maintenance Type Group Properties while adding new instance
        /// </summary>
        private void SetMaintenanceTypeGroupProperties(MaintenanceTypeGroup maintenanceTypeGroup, MaintenanceTypeGroup dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = mainteneceTypeGroupRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = mainteneceTypeGroupRepository.UserDomainKey;
            dbVersion.MaintenanceTypeGroupCode = maintenanceTypeGroup.MaintenanceTypeGroupCode;
            dbVersion.MaintenanceTypeGroupName = maintenanceTypeGroup.MaintenanceTypeGroupName;
            dbVersion.MaintenanceTypeGroupDescription = maintenanceTypeGroup.MaintenanceTypeGroupDescription;
        }

        /// <summary>
        /// Update Maintenance Type Group Properties while updating the instance
        /// </summary>
        private void UpdateMaintenanceTypeGroupProperties(MaintenanceTypeGroup maintenanceTypeGroup, MaintenanceTypeGroup dbVersion)
        {
            dbVersion.RecLastUpdatedBy = mainteneceTypeGroupRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.MaintenanceTypeGroupCode = maintenanceTypeGroup.MaintenanceTypeGroupCode;
            dbVersion.MaintenanceTypeGroupName = maintenanceTypeGroup.MaintenanceTypeGroupName;
            dbVersion.MaintenanceTypeGroupDescription = maintenanceTypeGroup.MaintenanceTypeGroupDescription;
        }

        /// <summary>
        /// Check Document association with other entites before deletion
        /// </summary>
        private void CheckMainteneceTypeGroupAssociations(long mainteneceTypeGroupId)
        {
            // Association check b/w Maintenece Type Group and Maintenece Type
            if (maintenanceTypeRepository.IsMainteneceTypeGroupAssociatedWithMainteneceType(mainteneceTypeGroupId))
                throw new CaresException(Resources.FleetPool.MaintenanceTypeGroup.MaintenanceTypeGroupIsAssociatedWithMaintenanceTypeError);
          
        }
        #endregion

        #endregion
        #region Constructor
        /// <summary>
        ///  Document Constructor
        /// </summary>
        public MainteneceTypeGroupService(IMainteneceTypeGroupRepository mainteneceTypeGroupRepository, IMaintenanceTypeRepository maintenanceTypeRepository)
        {
            this.mainteneceTypeGroupRepository = mainteneceTypeGroupRepository;
            this.maintenanceTypeRepository = maintenanceTypeRepository;
        }

        #endregion
        #region Public


        // <summary>
        // Delete Maintenece Type Group by id
        // </summary>
        public void DeleteMainteneceTypeGroup(long mainteneceTypeGroupId)
        {
            MaintenanceTypeGroup dbversion = mainteneceTypeGroupRepository.Find(mainteneceTypeGroupId);
            CheckMainteneceTypeGroupAssociations(mainteneceTypeGroupId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Maintenece Type Group with Id {0} not found!", mainteneceTypeGroupId));
                }
            mainteneceTypeGroupRepository.Delete(dbversion);
            mainteneceTypeGroupRepository.SaveChanges();                
        }

        // <summary>
        // Search Maintenece Type Group
        // </summary>
        public MainteneceTypeGroupSearchRequestResponse SearchMainteneceTypeGroup(MainteneceTypeGroupSearchRequest request)
        {
            int rowCount;
            return new MainteneceTypeGroupSearchRequestResponse
            {
                MaintenanceTypeGroups = mainteneceTypeGroupRepository.SearchMainteneceTypeGroup(request, out rowCount),
                TotalCount = rowCount
            };
        }

        // <summary>
        // Add /Update Maintenece Type Group
        // </summary>
        public MaintenanceTypeGroup SaveMaintenanceTypeGroup(MaintenanceTypeGroup maintenanceTypeGroup)
        {
            MaintenanceTypeGroup dbVersion = mainteneceTypeGroupRepository.Find(maintenanceTypeGroup.MaintenanceTypeGroupId);

            if (mainteneceTypeGroupRepository.IsMaintenanceTypeGroupCodeExist(maintenanceTypeGroup))            
            throw new CaresException(Resources.FleetPool.MaintenanceTypeGroup.MaintenanceTypeGroupCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateMaintenanceTypeGroupProperties(maintenanceTypeGroup, dbVersion);
                    mainteneceTypeGroupRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new MaintenanceTypeGroup();
                    SetMaintenanceTypeGroupProperties(maintenanceTypeGroup, dbVersion);
                    mainteneceTypeGroupRepository.Add(dbVersion);
                }
                mainteneceTypeGroupRepository.SaveChanges();
                // To Load the proprties
                return mainteneceTypeGroupRepository.Find(dbVersion.MaintenanceTypeGroupId);
        }

       
        /// <summary>
        /// Load All Maintenance Type Groups
        /// </summary>
        public IEnumerable<MaintenanceTypeGroup> LoadAll()
        {
            return mainteneceTypeGroupRepository.GetAll();
        }
        #endregion
    }
}
