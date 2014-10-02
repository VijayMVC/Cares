using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    ///Business Partner Relationship Type Service
    /// </summary>
    public class BusinessPartnerRelationTypeService : IBusinessPartnerRelationTypeService
    {
        #region Private
        private readonly IBusinessPartnerRelationshipTypeRepository businessPartnerRelationshipTypeRepository;
        private readonly IBusinessPartnerRelationshipRepository bPRelationshipRepository;
       
        /// <summary>
        /// Set newly created Business Partner Relationship Type object Properties in case of adding
        /// </summary>
        private void SetBusinessPartnerRelationshipTypeProperties(BusinessPartnerRelationshipType businessPartnerRelationshipType,
            BusinessPartnerRelationshipType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = businessPartnerRelationshipTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.BusinessPartnerRelationshpTypeCode = businessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode;
            dbVersion.BusinessPartnerRelationshipTypeName = businessPartnerRelationshipType.BusinessPartnerRelationshipTypeName;
            dbVersion.BusinessPartnerRelationshipTypeDescription = businessPartnerRelationshipType.BusinessPartnerRelationshipTypeDescription;
            dbVersion.UserDomainKey = businessPartnerRelationshipTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update Business Partner Relationship Type object Properties in case of updation
        /// </summary>
        protected void UpdateBusinessPartnerRelationshipTypePropertie(BusinessPartnerRelationshipType businessPartnerRelationshipType, 
            BusinessPartnerRelationshipType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = businessPartnerRelationshipTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BusinessPartnerRelationshpTypeCode = businessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode;
            dbVersion.BusinessPartnerRelationshipTypeName = businessPartnerRelationshipType.BusinessPartnerRelationshipTypeName;
            dbVersion.BusinessPartnerRelationshipTypeDescription = businessPartnerRelationshipType.BusinessPartnerRelationshipTypeDescription;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long businessPartnerRelationTypeId)
        {
            // Assocoation check 
            if (bPRelationshipRepository.IsBusinessPartnerRelationshipAssociatedBusinessPartnerRelationshipType(businessPartnerRelationTypeId))
                throw new CaresException(Resources.BusinessPartner.BusinessPartnerRelationshipType.
                    BusinessPartnerRelationshipTypeIsAssociatedWithBusinessPartnerRelationshipError);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRelationTypeService(IBusinessPartnerRelationshipTypeRepository businessPartnerRelationshipTypeRepository, IBusinessPartnerRelationshipRepository bPRelationshipRepository)
        {
            this.businessPartnerRelationshipTypeRepository = businessPartnerRelationshipTypeRepository;
            this.bPRelationshipRepository = bPRelationshipRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Business Partner Relationship Types
        /// </summary>
        public IEnumerable<BusinessPartnerRelationshipType> LoadAll()
        {
            return businessPartnerRelationshipTypeRepository.GetAll();
        }

        /// <summary>
        /// Search Business Partner Relation Type
        /// </summary>
        public BusinessPartnerRelationTypeSearchRequestResponse SearchBusinessPartnerRelationType(BusinessPartnerRelationTypeSearchRequest request)
        {
            int rowCount;
            return new BusinessPartnerRelationTypeSearchRequestResponse
            {
                BusinessPartnerRelationshipTypes = businessPartnerRelationshipTypeRepository.SearchBusinessPartnerRelationshipType(request, out rowCount),
                TotalCount = rowCount
            };
        }

       /// <summary>
        /// Delete Business Partner Relation Type by id
        /// </summary>
        public void DeleteBusinessPartnerRelationType(long businessPartnerRelationTypeId)
        {
            BusinessPartnerRelationshipType dbversion = businessPartnerRelationshipTypeRepository.Find((int)businessPartnerRelationTypeId);
            ValidateBeforeDeletion(businessPartnerRelationTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Business Partner Relation Type with Id {0} not found!", businessPartnerRelationTypeId));
            }
            businessPartnerRelationshipTypeRepository.Delete(dbversion);
            businessPartnerRelationshipTypeRepository.SaveChanges();  
        }
        /// <summary>
        /// Add /Update Busines sPartner Relationship Type
        /// </summary>
        public BusinessPartnerRelationshipType SaveBusinessPartnerRelationType(BusinessPartnerRelationshipType businessPartnerRelationshipType)
        {
            BusinessPartnerRelationshipType dbVersion = businessPartnerRelationshipTypeRepository.Find(businessPartnerRelationshipType.BusinessPartnerRelationshipTypeId);

            //Code Duplication Check
            if (businessPartnerRelationshipTypeRepository.BusinessPartnerRelationshipTypeCodeDuplicationCheck(businessPartnerRelationshipType))
                throw new CaresException(Resources.BusinessPartner.BusinessPartnerRelationshipType.BusinessPartnerRelationshipTypeCodeDuplicationError);

            if (dbVersion != null)
            {
                UpdateBusinessPartnerRelationshipTypePropertie(businessPartnerRelationshipType, dbVersion);
                businessPartnerRelationshipTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new BusinessPartnerRelationshipType();
                SetBusinessPartnerRelationshipTypeProperties(businessPartnerRelationshipType, dbVersion);
                businessPartnerRelationshipTypeRepository.Add(dbVersion);
            }
            businessPartnerRelationshipTypeRepository.SaveChanges();
            // To Load the proprties
            return businessPartnerRelationshipTypeRepository.Find(dbVersion.BusinessPartnerRelationshipTypeId);
        }
        #endregion
    }
}