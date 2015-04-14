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
    /// Insurance Type Service
    /// </summary>
    public class InsuranceTypeService : IInsuranceTypeService
    {
        #region Private
        
        private readonly IInsuranceTypeRepository insuranceTypeRepository;

        private readonly IInsuranceRtRepository insuranceRtRepository;
        private readonly IVehicleInsuranceInfoRepository vehicleInsuranceInfoRepository;


        #region Methods
        /// <summary>
        /// Set Insurance Type Properties while adding new instance
        /// </summary>
        private void SetInsuranceTypeProperties(InsuranceType insuranceType, InsuranceType dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = insuranceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = insuranceTypeRepository.UserDomainKey;
            dbVersion.InsuranceTypeCode = insuranceType.InsuranceTypeCode;
            dbVersion.InsuranceTypeName = insuranceType.InsuranceTypeName;
            dbVersion.InsuranceTypeDescription = insuranceType.InsuranceTypeDescription;
        }

        /// <summary>
        /// Update Insurance Type Properties while updating the instance
        /// </summary>
        private void UpdateInsuranceTypeProperties(InsuranceType insuranceType, InsuranceType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = insuranceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.InsuranceTypeCode = insuranceType.InsuranceTypeCode;
            dbVersion.InsuranceTypeName = insuranceType.InsuranceTypeName;
            dbVersion.InsuranceTypeDescription = insuranceType.InsuranceTypeDescription;
        }

        /// <summary>
        /// Check Insurance Type association with other entites before deletion
        /// </summary>
        private void CheckInsuranceTypeAssociations(long insuranceTypeId)
        {
            // Association check B/W Insurance Type and Insurance RT
            if (insuranceRtRepository.IsInsuranceTypeAssociatedWithInsuranceRt(insuranceTypeId))
                throw new CaresException(Resources.FleetPool.InsuranceType.InsuranceTypeIsAssociatedWithInsuranceRTError);

            //  Association check of InsuranceType and vehicle Insurance Info
            if (vehicleInsuranceInfoRepository.IsInsuranceTypeAssociatedWithVehicleInsuranceInfo(insuranceTypeId))
                throw new CaresException(Resources.FleetPool.InsuranceType.InsuranceTypeIsAssociatedWithVehicleInsuranceInfoError);

        }
        #endregion
        #endregion
        #region Constructors

        public InsuranceTypeService(IInsuranceTypeRepository insuranceTypeRepository, IInsuranceRtRepository insuranceRtRepository, IVehicleInsuranceInfoRepository vehicleInsuranceInfoRepository)
        {
            if (insuranceTypeRepository == null)
            {
                throw new ArgumentNullException("insuranceTypeRepository");
            }

            this.insuranceTypeRepository = insuranceTypeRepository;
            this.insuranceRtRepository = insuranceRtRepository;
            this.vehicleInsuranceInfoRepository = vehicleInsuranceInfoRepository;
        }

        #endregion
        #region Public
        
        /// <summary>
        /// Get All For RA
        /// </summary>
        public IEnumerable<InsuranceType> GetAllForRa()
        {
            return insuranceTypeRepository.GetAll();
        }


        /// <summary>
        /// Search Insurance Type
        /// </summary>
        public InsuranceTypeSearchRequestResponse SearchInsuranceType(InsuranceTypeSearchRequest request)
        {
            int rowCount;
            return new InsuranceTypeSearchRequestResponse
            {
                InsuranceTypes = insuranceTypeRepository.SearchInsuranceType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Add / Update Insurance Type
        /// </summary>
        public InsuranceType AddUpdateInsuranceType(InsuranceType insuranceType)
        {
            InsuranceType dbVersion = insuranceTypeRepository.Find(insuranceType.InsuranceTypeId);

            if (insuranceTypeRepository.InsuranceTypeCodeDuplicationCheck(insuranceType))
                throw new CaresException(Resources.FleetPool.InsuranceType.InsuranceTypeCodeDuplicationError);

            if (dbVersion != null)
            {
                UpdateInsuranceTypeProperties(insuranceType, dbVersion);
                insuranceTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new InsuranceType();
                SetInsuranceTypeProperties(insuranceType, dbVersion);
                insuranceTypeRepository.Add(dbVersion);
            }
            insuranceTypeRepository.SaveChanges();
            // To Load the proprties
            return insuranceTypeRepository.Find(dbVersion.InsuranceTypeId);
        }

        /// <summary>
        /// Delete Insurance Type
        /// </summary>
        public void DeleteInsuranceType(long insuranceTypeId)
        {
            InsuranceType dbversion = insuranceTypeRepository.Find(insuranceTypeId);
            CheckInsuranceTypeAssociations(insuranceTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.FleetPool.InsuranceType.InsuranceTypeNotFoundInDatabase));
            }
            insuranceTypeRepository.Delete(dbversion);
            insuranceTypeRepository.SaveChanges();  
        }

        #endregion
    }
}
