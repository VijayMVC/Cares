using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Legal Status Service
    /// </summary>
    public class BusinessLegalStatusService : IBusinessLegalStatusService
    {
        #region Private
        private readonly IBusinessLegalStatusRepository businessLegalStatusRepository;
        private readonly IBusinessPartnerRepository businessPartnerRepository;

        /// <summary>
        /// Set Business Legal Status Properties while adding new instance
        /// </summary>
        private void SetBusinessLegalStatusProperties(BusinessLegalStatus businessLegalStatusRequest, BusinessLegalStatus dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = businessLegalStatusRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = 1;
            dbVersion.BusinessLegalStatusCode = businessLegalStatusRequest.BusinessLegalStatusCode;
            dbVersion.BusinessLegalStatusName = businessLegalStatusRequest.BusinessLegalStatusName;
            dbVersion.BusinessLegalStatusDescription = businessLegalStatusRequest.BusinessLegalStatusDescription;
        }

        /// <summary>
        /// Update Business Legal Status Properties while updating the instance
        /// </summary>
        private void UpdateBusinessLegalStatusProperties(BusinessLegalStatus businessLegalStatusRequest, BusinessLegalStatus dbVersion)
        {
            dbVersion.RecLastUpdatedBy = businessLegalStatusRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BusinessLegalStatusCode = businessLegalStatusRequest.BusinessLegalStatusCode;
            dbVersion.BusinessLegalStatusName = businessLegalStatusRequest.BusinessLegalStatusName;
            dbVersion.BusinessLegalStatusDescription = businessLegalStatusRequest.BusinessLegalStatusDescription;
        }

        /// <summary>
        /// Check Document association with other entites before deletion
        /// </summary>
        private void CheckBusinessLegalStatusAssociations(long businessLegalStatusId)
        {
            // Business Legal Status - BP association checking
            if (businessPartnerRepository.IsBusinessPartnerAssociatedWithBusinessLegalStatus(businessLegalStatusId))
                throw new CaresException(Resources.BusinessPartner.BusinessLegalStatus.BusinessLegalStatusIsAssociatedWithBusinessPartner);

        }
        #endregion
        #region Constructor
        public BusinessLegalStatusService(IBusinessLegalStatusRepository businessLegalStatusRepository, IBusinessPartnerRepository businessPartnerRepository)
        {
            this.businessLegalStatusRepository = businessLegalStatusRepository;
            this.businessPartnerRepository = businessPartnerRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Get All Business Legal Statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessLegalStatus> LoadAll()
        {
            return businessLegalStatusRepository.GetAll();
        }

        /// <summary>
        /// Search  Business Legal Status
        /// </summary>
        public BusinessLegalStatusSearchRequestRespose SearchBusinessLegalStatus(BusinessLegalStatusSearchRequest request)
        {
            int rowCount;
            return new BusinessLegalStatusSearchRequestRespose
            {
                BusinessLegalStatuses = businessLegalStatusRepository.SearchBusinessLegalStatus(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Business Legal Status
        /// </summary>
        public void DeleteBusinessLegalStatus(long businessLegalStatusId)
        {
            BusinessLegalStatus dbversion = businessLegalStatusRepository.Find(businessLegalStatusId);
            CheckBusinessLegalStatusAssociations(businessLegalStatusId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Business Legal Status with Id {0} not found!", businessLegalStatusId));
            }
            businessLegalStatusRepository.Delete(dbversion);
            businessLegalStatusRepository.SaveChanges();    
        }


        /// <summary>
        /// Add / Update Business Legal Status
        /// </summary>
        public BusinessLegalStatus AddUpdateBusinessLegalStatus(BusinessLegalStatus businessLegalStatusRequest)
        {
            BusinessLegalStatus dbVersion = businessLegalStatusRepository.Find(businessLegalStatusRequest.BusinessLegalStatusId);

            if (businessLegalStatusRepository.BusinessLegalStatusCodeDuplicationCheck(businessLegalStatusRequest))
                throw new CaresException(Resources.BusinessPartner.BusinessLegalStatus.BusinessLegalStatusCodeDuplicationError);

            if (dbVersion != null)
            {
                UpdateBusinessLegalStatusProperties(businessLegalStatusRequest, dbVersion);
                businessLegalStatusRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new BusinessLegalStatus();
                SetBusinessLegalStatusProperties(businessLegalStatusRequest, dbVersion);
                businessLegalStatusRepository.Add(dbVersion);
            }
            businessLegalStatusRepository.SaveChanges();
            // To Load the proprties
            return businessLegalStatusRepository.Find(dbVersion.BusinessLegalStatusId);
        }
        #endregion
    }
}
