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
    /// Maintenance Type Service
    /// </summary>
    public class MaintenanceTypeService : IMaintenanceTypeService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IMaintenanceTypeRepository maintenanceTypeRepository;
        private readonly IMainteneceTypeGroupRepository mainteneceTypeGroupRepository;
        private readonly IVehicleMaintenanceTypeFrequencyRepository vehicleMaintenanceTypeFrequencyRepository;

        #region Private Methodes
        /// <summary>
        /// Set Maintenance Type Properties while adding new instance
        /// </summary>
        private void SetMaintenanceTypeProperties(MaintenanceType maintenanceType, MaintenanceType dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = maintenanceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = maintenanceTypeRepository.UserDomainKey;
            dbVersion.MaintenanceTypeCode = maintenanceType.MaintenanceTypeCode;
            dbVersion.MaintenanceTypeName = maintenanceType.MaintenanceTypeName;
            dbVersion.MaintenanceTypeDescription = maintenanceType.MaintenanceTypeDescription;
            dbVersion.MaintenanceTypeGroupId = maintenanceType.MaintenanceTypeGroupId;
        }

        /// <summary>
        /// Update Maintenance Type Properties while updating the instance
        /// </summary>
        private void UpdateMaintenanceTypeProperties(MaintenanceType maintenanceType, MaintenanceType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = maintenanceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.MaintenanceTypeCode = maintenanceType.MaintenanceTypeCode;
            dbVersion.MaintenanceTypeName = maintenanceType.MaintenanceTypeName;
            dbVersion.MaintenanceTypeDescription = maintenanceType.MaintenanceTypeDescription;
            dbVersion.MaintenanceTypeGroupId = maintenanceType.MaintenanceTypeGroupId;
        }

        /// <summary>
        /// Check Maintenance Type association with other entites before deletion
        /// </summary>
        private void CheckMaintenanceTypeAssociations(long maintenanceTypeId)
        {
            // Association check b/w vehicle Maintenance Type Frequency and Maintenance Type
            if (vehicleMaintenanceTypeFrequencyRepository.IsVehicleMaintenanceTypeFrequencyAssociatedMaintenanceType(maintenanceTypeId))
                throw new CaresException(Resources.FleetPool.MaintenanceType.MaintenanceTypeIsAssociatedWithVehicleMaintenanceTypeFrequencyError);

        }
        #endregion

        #endregion
        #region Constructor
        /// <summary>
        ///   Constructor
        /// </summary>
        public MaintenanceTypeService(IMaintenanceTypeRepository maintenanceTypeRepository, IMainteneceTypeGroupRepository mainteneceTypeGroupRepository,
            IVehicleMaintenanceTypeFrequencyRepository vehicleMaintenanceTypeFrequencyRepository)
        {
            this.mainteneceTypeGroupRepository = mainteneceTypeGroupRepository;
            this.maintenanceTypeRepository = maintenanceTypeRepository;
            this.vehicleMaintenanceTypeFrequencyRepository = vehicleMaintenanceTypeFrequencyRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Base data of Maintenance Type
        /// </summary>
        public MaintenanceTypeBaseDataResponse LoadMaintenanceTypeBaseData()
        {
            return new MaintenanceTypeBaseDataResponse
            {
                MaintenanceTypeGroups = mainteneceTypeGroupRepository.GetAll()
            };
        }

         /// <summary>
        /// Delete Maintenance Type
        /// </summary>
        public void DeleteMaintenanceType(long maintenanceTypeId)
        {
            MaintenanceType dbversion = maintenanceTypeRepository.Find(maintenanceTypeId);
            CheckMaintenanceTypeAssociations(maintenanceTypeId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Maintenance Type with Id {0} not found!", maintenanceTypeId));
                }
            maintenanceTypeRepository.Delete(dbversion);
            maintenanceTypeRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Maintenance Type
        /// </summary>
        public MaintenanceTypeSearchRequestResponse SearchMaintenanceType(MaintenanceTypeSearchRequest request)
        {
            int rowCount;
            return new MaintenanceTypeSearchRequestResponse
            {
                MaintenanceTypes = maintenanceTypeRepository.SearchMaintenanceType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Add / Update  Maintenance Type
        /// </summary>
        public MaintenanceType AddUpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            MaintenanceType dbVersion = maintenanceTypeRepository.Find(maintenanceType.MaintenanceTypeId);

            if (maintenanceTypeRepository.MaintenanceTypeCodeDuplicationCheck(maintenanceType))            
            throw new CaresException(Resources.FleetPool.MaintenanceType.MaintenanceTypeCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateMaintenanceTypeProperties(maintenanceType, dbVersion);
                    maintenanceTypeRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new MaintenanceType();
                    SetMaintenanceTypeProperties(maintenanceType, dbVersion);
                    maintenanceTypeRepository.Add(dbVersion);
                }
                maintenanceTypeRepository.SaveChanges();
                // To Load the proprties
                return maintenanceTypeRepository.LoadMaintenanceTypeWithDetail(dbVersion.MaintenanceTypeId);
        }

       
        /// <summary>
        /// Load All Maintenance Types
        /// </summary>
        public IEnumerable<MaintenanceType> LoadAll()
        {
            return maintenanceTypeRepository.GetAll();
        }
        #endregion
    }
}
