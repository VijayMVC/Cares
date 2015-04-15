using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Segment Service
    /// </summary>
    public  class BusinessSegmentService : IBusinessSegmentService
    {
        #region Private
        private readonly IBusinessSegmentRepository businessSegmentRepository;
        private readonly ICompanyRepository companyRepository;


        /// <summary>
        /// Method to update Business Segment  properties
        /// </summary>
        private void UpdateBusinessSegmentProPerties(BusinessSegment businessSegment, BusinessSegment dbVersion)
        {
            dbVersion.RecLastUpdatedBy = businessSegmentRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BusinessSegmentCode = businessSegment.BusinessSegmentCode;
            dbVersion.BusinessSegmentName = businessSegment.BusinessSegmentName;
            dbVersion.BusinessSegmentDescription = businessSegment.BusinessSegmentDescription;
        }

        /// <summary>
        /// Method to Add Business Segment properties
        /// </summary>
        private void SetNewBusinessSegmentProPerties(BusinessSegment businessSegment)
        {
            businessSegment.RecCreatedBy =
                businessSegment.RecLastUpdatedBy = businessSegmentRepository.LoggedInUserIdentity;
            businessSegment.RecCreatedDt = businessSegment.RecLastUpdatedDt = DateTime.Now;
            businessSegment.RowVersion = 0;
            businessSegment.UserDomainKey = businessSegmentRepository.UserDomainKey;
        }

        /// <summary>
        /// check association with company before deletion
        /// </summary>
        private void ValidateAssociation(long businessSegmentId)
        {
            if (companyRepository.IsCompanyAssiciatedWithBusinessSegment(businessSegmentId))
                throw new CaresException(Resources.Organization.BusinessSegment.BusinessSegmentIsAssociatedWithCompanyError);
        }


        #endregion
        #region Constructor
        public BusinessSegmentService(IBusinessSegmentRepository businessSegmentRepository, ICompanyRepository companyRepository)
        {
            this.businessSegmentRepository = businessSegmentRepository;
            this.companyRepository = companyRepository;
        }

        #endregion
        #region Public
        /// <summary>
        /// Search BusinessSegment
        /// </summary>
        public BusinessSegmentSearchRequestResponse SearchBusinessSegment(BusinessSegmentSearchRequest request)
        {
            int rowCount;
            return new BusinessSegmentSearchRequestResponse
            {
                BusinessSegments = businessSegmentRepository.SearchBusinessSegment(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Delete BusinessSegment by BusinessSegmentId
        /// </summary>
        public void DeleteBusinessSegment(long businessSegmentId)
        {
            BusinessSegment dbversion = businessSegmentRepository.Find(businessSegmentId);
            ValidateAssociation(businessSegmentId);
            if (dbversion == null)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.Organization.BusinessSegment.BusinessSegmentNotFoundInDatabase));
            businessSegmentRepository.Delete(dbversion);
            businessSegmentRepository.SaveChanges();  
        }

        /// <summary>
        /// Add or Update Business Segment object
        /// </summary>
        public BusinessSegment AddUpdateBusinessSegment(BusinessSegment businessSegment)
        {
            BusinessSegment dbVersion = businessSegmentRepository.Find(businessSegment.BusinessSegmentId);
             //Code Duplication Check
            if (businessSegmentRepository.IsBusinessSegmentCodeExists(businessSegment))
                throw new CaresException(Resources.Organization.BusinessSegment.BusinessSegmentCodeExistsError);
            if (dbVersion != null)
            {
                UpdateBusinessSegmentProPerties(businessSegment, dbVersion);
                businessSegmentRepository.Update(dbVersion);
            }
            else
            {
                SetNewBusinessSegmentProPerties(businessSegment);
                businessSegmentRepository.Add(businessSegment);
            }
            businessSegmentRepository.SaveChanges();
                // To Load the proprties
                return businessSegmentRepository.Find(businessSegment.BusinessSegmentId);
        }


        #endregion
    }
}
