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
    /// Rating Type Service
    /// </summary>
    public class RatingTypeService : IRatingTypeService
    {
        #region Private
        private readonly IBpRatingTypeRepository bpRatingTypeRepository;
        private readonly ICreditLimitRepository creditLimitRepository;
        private readonly IBusinessPartnerRepository businessPartnerRepository;
       

        /// <summary>
        /// Set newly created Rating Type object Properties in case of adding
        /// </summary>
        private void SetRatingTypeProperties(BpRatingType ratingType, BpRatingType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = bpRatingTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.BpRatingTypeCode = ratingType.BpRatingTypeCode;
            dbVersion.BpRatingTypeName = ratingType.BpRatingTypeName;
            dbVersion.BpRatingTypeDescription = ratingType.BpRatingTypeDescription;
            dbVersion.UserDomainKey = bpRatingTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update Rating Type object Properties in case of updation
        /// </summary>
        private void UpdateRatingTypePropertie(BpRatingType ratingType, BpRatingType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = bpRatingTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BpRatingTypeCode = ratingType.BpRatingTypeCode;
            dbVersion.BpRatingTypeName = ratingType.BpRatingTypeName;
            dbVersion.BpRatingTypeDescription = ratingType.BpRatingTypeDescription;
        }

       
        //Validation check for deletion
        private void ValidateBeforeDeletion(long ratingTypeId)
        {
            // Assocoation with credit limit check
            if (creditLimitRepository.IsRatingTypeAssociatedWithCreditLimit(ratingTypeId))
                throw new CaresException(Resources.BusinessPartner.RatingType.RatingTypeIsAssociatedWithCreditLimit);
            // Assocoation with credit Business Partner
            if (businessPartnerRepository.IsBusinessPartnerAssociatedWithRatingType(ratingTypeId))
                throw new CaresException(Resources.BusinessPartner.RatingType.RatingTypeIsAssociatedWithBPMain);

        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RatingTypeService(IBpRatingTypeRepository bpRatingTypeRepository, ICreditLimitRepository creditLimitRepository, IBusinessPartnerRepository businessPartnerRepository)
        {
            this.bpRatingTypeRepository = bpRatingTypeRepository;
            this.creditLimitRepository = creditLimitRepository;
            this.businessPartnerRepository = businessPartnerRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Rating Types
        /// </summary>
        public IEnumerable<BpRatingType> LoadAll()
        {
            return bpRatingTypeRepository.GetAll();
        }

        /// <summary>
        /// Search Rating Type
        /// </summary>
        public RatingTypeSearchRequestResponse SearchRatingType(RatingTypeSearchRequest request)
        {
            int rowCount;
            return new RatingTypeSearchRequestResponse
            {
                RatingTypes = bpRatingTypeRepository.SearchRatingType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Rating Type by id
        /// </summary>
        public void DeleteRatingType(long ratingTypeId)
        {
            BpRatingType dbversion = bpRatingTypeRepository.Find((int)ratingTypeId);
            ValidateBeforeDeletion(ratingTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Rating Type with Id {0} not found!", ratingTypeId));
            }
            bpRatingTypeRepository.Delete(dbversion);
            bpRatingTypeRepository.SaveChanges();
        }

        /// <summary>
        /// Add /Update Rating Type
        /// </summary>
        public BpRatingType SaveRatingType(BpRatingType bpRatingType)
        {
            BpRatingType dbVersion = bpRatingTypeRepository.Find(bpRatingType.BpRatingTypeId);
            //Code Duplication Check
            if (bpRatingTypeRepository.DoesRatingTypeCodeExist(bpRatingType))
                throw new CaresException(Resources.BusinessPartner.RatingType.RatingTypeCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateRatingTypePropertie(bpRatingType, dbVersion);
                bpRatingTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new BpRatingType();
                SetRatingTypeProperties(bpRatingType, dbVersion);
                bpRatingTypeRepository.Add(dbVersion);
            }
            bpRatingTypeRepository.SaveChanges();
            // To Load the proprties
            return bpRatingTypeRepository.Find(dbVersion.BpRatingTypeId);
        }
        #endregion
    }
}