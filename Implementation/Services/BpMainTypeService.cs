using System;
using System.Collections.Generic;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Partner Main Type Service
    /// </summary>
    public class BpMainTypeService : IBpMainTypeService
    {
        #region Private
        private readonly IBpMainTypeRepository bpMainTypeRepository;
        private readonly IBpSubTypeRepository bpSubTypeRepository;
       
        /// <summary>
        /// Set newly createdBusiness Partner Main Type object Properties in case of adding
        /// </summary>
        private void SetBpMainTypeProperties(BusinessPartnerMainType businessPartnerMainType, BusinessPartnerMainType dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = bpMainTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.BusinessPartnerMainTypeCode = businessPartnerMainType.BusinessPartnerMainTypeCode;
            dbVersion.BusinessPartnerMainTypeName = businessPartnerMainType.BusinessPartnerMainTypeName;
            dbVersion.BusinessPartnerMainTypeDescription = businessPartnerMainType.BusinessPartnerMainTypeDescription;
            dbVersion.BusinessPartnerMainTypeKey = businessPartnerMainType.BusinessPartnerMainTypeKey;
            dbVersion.UserDomainKey = bpMainTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update Business Partner Main Type object Properties in case of updation
        /// </summary>
        protected void UpdateBpMainTypePropertie(BusinessPartnerMainType businessPartnerMainType, BusinessPartnerMainType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = bpMainTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BusinessPartnerMainTypeCode = businessPartnerMainType.BusinessPartnerMainTypeCode;
            dbVersion.BusinessPartnerMainTypeName = businessPartnerMainType.BusinessPartnerMainTypeName;
            dbVersion.BusinessPartnerMainTypeDescription = businessPartnerMainType.BusinessPartnerMainTypeDescription;
            dbVersion.BusinessPartnerMainTypeKey = businessPartnerMainType.BusinessPartnerMainTypeKey;

        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long bpMainTypeId)
        {
            // Assocoation with Sub Sub Tpe check 
            if (bpSubTypeRepository.IsBpSubTypeAssociatedWithBpMainType(bpMainTypeId))
                throw new CaresException(Resources.BusinessPartner.BpMainType.BpMainTypeIsAssociatedWithBpSubType); 
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpMainTypeService(IBpMainTypeRepository bpMainTypeRepository, IBpSubTypeRepository bpSubTypeRepository)
        {
            this.bpMainTypeRepository = bpMainTypeRepository;
            this.bpSubTypeRepository = bpSubTypeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Business Partner Main Types
        /// </summary>
        public IEnumerable<BusinessPartnerMainType> LoadAll()
        {
            return bpMainTypeRepository.GetAll();
        }

        /// <summary>
        /// Search Business Partner Main Type
        /// </summary>
        public BpMainTypeSearchRequestResponse SearchBpMainType(BpMainTypeSearchRequest request)
        {
            int rowCount;
            return new BpMainTypeSearchRequestResponse
            {
                BpMainTypes = bpMainTypeRepository.SearchBpMainType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Business Partner Main Type by id
        /// </summary>
        public void DeleteBpMainType(long bpMainTypeId)
        {
             BusinessPartnerMainType dbversion = bpMainTypeRepository.Find((int)bpMainTypeId);
            ValidateBeforeDeletion(bpMainTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BusinessPartner.BpMainType.BPMainTypeNotFound));
            }
            bpMainTypeRepository.Delete(dbversion);
            bpMainTypeRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Business Partner Main Type
        /// </summary>
        public BusinessPartnerMainType SaveBpMainType(BusinessPartnerMainType bpMainType)
        {
            BusinessPartnerMainType dbVersion = bpMainTypeRepository.Find(bpMainType.BusinessPartnerMainTypeId);

            //Code Duplication Check
            if (bpMainTypeRepository.DoesBpMainTypeCodeExists(bpMainType))
                throw new CaresException(Resources.BusinessPartner.BpMainType.BpMainTypeCodeDuplicationError); 
            if (dbVersion != null)
            {
                UpdateBpMainTypePropertie(bpMainType, dbVersion);
                bpMainTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new BusinessPartnerMainType();
                SetBpMainTypeProperties(bpMainType, dbVersion);
                bpMainTypeRepository.Add(dbVersion);
            }
            bpMainTypeRepository.SaveChanges();
            // To Load the proprties
            return bpMainTypeRepository.Find(dbVersion.BusinessPartnerMainTypeId);
        }
        #endregion
    }
}