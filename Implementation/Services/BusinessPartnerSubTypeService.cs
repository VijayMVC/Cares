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
    /// Business Partner Sub Type Service
    /// </summary>
    public class BusinessPartnerSubTypeService : IBusinessPartnerSubTypeService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IBusinessPartnerSubTypeRepository businessPartnerSubTypeRepository;
        private readonly IBusinessPartnerMainTypeRepository businessPartnerMainTypeRepository;
        private readonly ICreditLimitRepository creditLimitRepository;
        private readonly IBusinessPartnerInTypeRepository businessPartnerInTypeRepository;

        #region Methods
        /// <summary>
        /// Set Business Partner Sub Type Properties while adding new instance
        /// </summary>
        private void SetBusinessPartnerSubTypeProperties(BusinessPartnerSubType businessPartnerSubType, BusinessPartnerSubType dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = businessPartnerSubTypeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = businessPartnerSubTypeRepository.UserDomainKey;
            dbVersion.BusinessPartnerSubTypeCode = businessPartnerSubType.BusinessPartnerSubTypeCode;
            dbVersion.BusinessPartnerSubTypeName = businessPartnerSubType.BusinessPartnerSubTypeName;
            dbVersion.BusinessPartnerSubTypeDescription = businessPartnerSubType.BusinessPartnerSubTypeDescription;
            dbVersion.BusinessPartnerMainTypeId = businessPartnerSubType.BusinessPartnerMainTypeId;
        }

        /// <summary>
        /// Update Business Partner Sub Type Properties while updating the instance
        /// </summary>
        private void UpdateBusinessPartnerSubTypeProperties(BusinessPartnerSubType businessPartnerSubType, BusinessPartnerSubType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = businessPartnerSubTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BusinessPartnerSubTypeCode = businessPartnerSubType.BusinessPartnerSubTypeCode;
            dbVersion.BusinessPartnerSubTypeName = businessPartnerSubType.BusinessPartnerSubTypeName;
            dbVersion.BusinessPartnerSubTypeDescription = businessPartnerSubType.BusinessPartnerSubTypeDescription;
            dbVersion.BusinessPartnerMainTypeId = businessPartnerSubType.BusinessPartnerMainTypeId;
            dbVersion.UserDomainKey = businessPartnerSubTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// Check Business Partner Sub Type association with other entites before deletion
        /// </summary>
        private void CheckBusinessPartnerSubTypeAssociations(long businessPartnerSubTypeId)
        {
            // Busines sPartner Sub Type - Credit Limit association checking
            if (creditLimitRepository.IsBusinessPartnerSubTypeAssociatedWithCreditLimit(businessPartnerSubTypeId))
                throw new CaresException(Resources.BusinessPartner.BusinessPartnerSubType.BusinessPartnerSubTypeIsAssociatedWithCreditLimit);

            // Business Partner Sub Type - Business Partner In Type association checking
            if (businessPartnerInTypeRepository.IsBusinessPartnerSubTypeAssociatedWithBusinessPartnerInType(businessPartnerSubTypeId))
                throw new CaresException(Resources.BusinessPartner.BusinessPartnerSubType.BusinessPartnerSubTypeIsAssociatedWithBusinessPartnerInType);

        }
        #endregion


        #endregion
        #region Constructor
        /// <summary>
        ///  Business Partner Sub Type Service Constructor
        /// </summary>
        public BusinessPartnerSubTypeService(IBusinessPartnerSubTypeRepository businessPartnerSubTypeRepository, IBusinessPartnerMainTypeRepository businessPartnerMainTypeRepository
             , ICreditLimitRepository creditLimitRepository, IBusinessPartnerInTypeRepository businessPartnerInTypeRepository)
        {
            this.businessPartnerMainTypeRepository = businessPartnerMainTypeRepository;
            this.businessPartnerSubTypeRepository = businessPartnerSubTypeRepository;
            this.creditLimitRepository = creditLimitRepository;
            this.businessPartnerInTypeRepository = businessPartnerInTypeRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Base data of Business Partner Sub Type
        /// </summary>
        public BusinessPartnerSubTypeBaseDataResponse LoadBusinessPartnerSubTypeBaseData()
        {
            return new BusinessPartnerSubTypeBaseDataResponse
            {
                BusinessPartnerMainType = businessPartnerMainTypeRepository.GetAll()
            };
        }

        /// <summary>
        /// Delete  Business Partner Sub Type
        /// </summary>
        public void DeleteBusinessPartnerSubType(long businessPartnerSubTypeId)
        {
            BusinessPartnerSubType dbversion = businessPartnerSubTypeRepository.Find((int) businessPartnerSubTypeId);
            CheckBusinessPartnerSubTypeAssociations(businessPartnerSubTypeId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BusinessPartner.BusinessPartnerSubType.BusinessPartnerSubTypeNotFound));
                }
            businessPartnerSubTypeRepository.Delete(dbversion);
            businessPartnerSubTypeRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Busines sPartner Sub Type
        /// </summary>
        public BusinessPartnerSubTypeSearchRequestResponse SearchBusinessPartnerSubType(BusinessPartnerSubTypeSearchRequest request)
        {
            int rowCount;
            return new BusinessPartnerSubTypeSearchRequestResponse
            {
                BusinessPartnerSubTypes = businessPartnerSubTypeRepository.SearchBusinessPartnerSubType(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Add / Update Business Partner Sub Type
        /// </summary>
        public BusinessPartnerSubType AddUpdateBusinessPartnerSubType(BusinessPartnerSubType businessPartnerSubType)
        {
            BusinessPartnerSubType dbVersion = businessPartnerSubTypeRepository.Find(businessPartnerSubType.BusinessPartnerSubTypeId);
            if (businessPartnerSubTypeRepository.BusinessPartnerSubTypeCodeDuplicationCheck(businessPartnerSubType))
            {
                throw new CaresException(
                    Resources.BusinessPartner.BusinessPartnerSubType.BusinessPartnerSubTypeCodeDuplicationError);}

            if (dbVersion != null)
            {
                UpdateBusinessPartnerSubTypeProperties(businessPartnerSubType, dbVersion);
                businessPartnerSubTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new BusinessPartnerSubType();
                SetBusinessPartnerSubTypeProperties(businessPartnerSubType, dbVersion);
                businessPartnerSubTypeRepository.Add(dbVersion);
            }
            businessPartnerSubTypeRepository.SaveChanges();
            // To Load the proprties
            return
                businessPartnerSubTypeRepository.LoadBusinessPartnerSubTypeWithDetail(dbVersion.BusinessPartnerSubTypeId);
        }

        /// <summary>
        /// Load All  Business PartnerSub Types
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> LoadAll()
        {
            return businessPartnerSubTypeRepository.GetAll();
        }
        #endregion
    }
}
