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
    /// Nrt Type Service
    /// </summary>
    public class NrtTypeService : INrtTypeService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly INrtTypeRepository nrtTypeRepository;
        private readonly IVehicleStatusRepository vehicleStatusRepository;
        private readonly INrtMainRepository nrtMainRepository;


        /// <summary>
        /// Set NrtType Properties while adding new instance
        /// </summary>
        private void SetNrtTypeProperties(NrtType nrtType, NrtType dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = nrtTypeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = 1;
            dbVersion.NrtTypeCode = nrtType.NrtTypeCode;
            dbVersion.NrtTypeName = nrtType.NrtTypeName;
            dbVersion.Description = nrtType.Description;
            dbVersion.NrtTypeKey = nrtType.NrtTypeKey;
            dbVersion.StandardLifeTime = nrtType.StandardLifeTime;
            dbVersion.VehicleStatusId = nrtType.VehicleStatusId;
        }

        /// <summary>
        /// Update Nrt Type Properties while updating the instance
        /// </summary>
        private void UpdateNrtTypeProperties(NrtType nrtType, NrtType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = nrtTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.NrtTypeCode = nrtType.NrtTypeCode;
            dbVersion.NrtTypeName = nrtType.NrtTypeName;
            dbVersion.Description = nrtType.Description;
            dbVersion.NrtTypeKey = nrtType.NrtTypeKey;
            dbVersion.StandardLifeTime = nrtType.StandardLifeTime;
            dbVersion.VehicleStatusId = nrtType.VehicleStatusId;
        }

        /// <summary>
        /// Check Nrt Type association with other entites before deletion
        /// </summary>
        private void CheckNrtTypeAssociations(long nrtTypeId)
        {
            // NrtType-NrtMain association checking
            if (nrtMainRepository.IsNrtMainAssociatedWithNrtType(nrtTypeId))
                throw new CaresException(Resources.NonRevenueTicket.NrtType.NrtTypeIsAssociatedWithNrtMainError);
            
        }


        #endregion
        #region Constructor
        /// <summary>
        ///  Nrt Type Service  Constructor
        /// </summary>
        public NrtTypeService(INrtTypeRepository nrtTypeRepository, IVehicleStatusRepository vehicleStatusRepository, INrtMainRepository nrtMainRepository)
        {
            this.nrtTypeRepository = nrtTypeRepository;
            this.vehicleStatusRepository = vehicleStatusRepository;
            this.nrtMainRepository = nrtMainRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Base data of NrtType
        /// </summary>
        public NrtTypeBaseDataResponse LoadNrtTypeBaseData()
        {
            return new NrtTypeBaseDataResponse
            {
                VehicleStatuses = vehicleStatusRepository.GetAll()
            };
        }


        /// <summary>
        /// Delete Ntr Type
        /// </summary>
        public void DeleteNtrType(long ntrTypeId)
        {
            NrtType dbversion = nrtTypeRepository.Find(ntrTypeId);
            CheckNrtTypeAssociations(ntrTypeId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Nrt Type with Id {0} not found!", ntrTypeId));
                }
            nrtTypeRepository.Delete(dbversion);
            nrtTypeRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Nrt Type
        /// </summary>
        public NrtTypeSearchRequestResponse SearchNrtType(NrtTypeSearchRequest request)
        {
            int rowCount;
            return new NrtTypeSearchRequestResponse
            {
                NrtTypes = nrtTypeRepository.SearchNrtType(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Add / Update Ntr Type
        /// </summary>
        public NrtType AddUpdateNtrType(NrtType nrtTypeRequest)
        {
            NrtType dbVersion = nrtTypeRepository.Find(nrtTypeRequest.NrtTypeId);
            if (nrtTypeRepository.IsNrtTypeCodeExists(nrtTypeRequest))
                 throw new CaresException(Resources.NonRevenueTicket.NrtType.NrtTypeCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateNrtTypeProperties(nrtTypeRequest, dbVersion);
                    nrtTypeRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new NrtType();
                    SetNrtTypeProperties(nrtTypeRequest, dbVersion);
                    nrtTypeRepository.Add(dbVersion);
                }

                nrtTypeRepository.SaveChanges();
                // To Load the proprties
                return nrtTypeRepository.GetNrtTypeWithDetails(dbVersion.NrtTypeId);
        }

       
        /// <summary>
        /// Load All Nrt Types
        /// </summary>
        public IEnumerable<NrtType> LoadAll()
        {
            return nrtTypeRepository.GetAll();
        }
        #endregion
    }
}
