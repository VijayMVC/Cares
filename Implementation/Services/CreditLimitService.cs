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
    /// Credit Limit Service
    /// </summary>
    public class CreditLimitService : ICreditLimitService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly ICreditLimitRepository creditLimitRepository;
        private readonly IBpSubTypeRepository subTypeRepository;
        private readonly IBpRatingTypeRepository ratingTypeRepository;

        /// <summary>
        /// Set Document Properties while adding new instance
        /// </summary>
        private void SetDocumentProperties(CreditLimit creditLimit, CreditLimit dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = creditLimitRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = 1;
            dbVersion.BpSubTypeId = creditLimit.BpSubTypeId;
            dbVersion.BpRatingTypeId = creditLimit.BpRatingTypeId;
            dbVersion.Description = creditLimit.Description;
            dbVersion.StandardCreditLimit = creditLimit.StandardCreditLimit;
            dbVersion.IsIndividual = creditLimit.IsIndividual;

        }

        /// <summary>
        /// Update Credit Limit Properties while updating the instance
        /// </summary>
        private void UpdateCreditLimitProperties(CreditLimit creditLimit, CreditLimit dbVersion)
        {
            dbVersion.RecLastUpdatedBy = creditLimitRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.BpSubTypeId = creditLimit.BpSubTypeId;
            dbVersion.BpRatingTypeId = creditLimit.BpRatingTypeId;
            dbVersion.Description = creditLimit.Description;
            dbVersion.StandardCreditLimit = creditLimit.StandardCreditLimit;
            dbVersion.IsIndividual = creditLimit.IsIndividual;

        }

      
        #endregion
        #region Constructor
        /// <summary>
        ///  Credit Limit Constructor
        /// </summary>
        public CreditLimitService(ICreditLimitRepository creditLimitRepository, IBpSubTypeRepository subTypeRepository, IBpRatingTypeRepository ratingTypeRepository)
        {
            this.creditLimitRepository = creditLimitRepository;
            this.subTypeRepository = subTypeRepository;
            this.ratingTypeRepository = ratingTypeRepository;
        }

        #endregion
        #region Public

        
        /// <summary>
        /// Load Base data of Credit Limit
        /// </summary>
        public CreditLimitBaseDataResponse LoadCreditLimitBaseData()
        {
            return new CreditLimitBaseDataResponse
            {
                BpRatingTypes = ratingTypeRepository.GetAll(),
                BusinessPartnerSubTypes = subTypeRepository.GetAll()
            };
        }

        /// <summary>
        /// Delete Credit Limit
        /// </summary>
        public void DeleteCreditLimit(long creditLimitid)
        {
            CreditLimit dbversion = creditLimitRepository.Find(creditLimitid);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Credit Limit with Id {0} not found!", creditLimitid));
                }
            creditLimitRepository.Delete(dbversion);
            creditLimitRepository.SaveChanges();                
        }

        /// <summary>
        /// Search Credit Limit
        /// </summary>
        public CreditLimitSearchRequestResponse SearchCreditLimit(CreditLimitSearchRequest request)
        {
            int rowCount;
            return new CreditLimitSearchRequestResponse
            {
                CreditLimits = creditLimitRepository.SearchCreditLimit(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Add / Update Credit Limit
        /// </summary>
        public CreditLimit AddUpdateCreditLimit(CreditLimit creditLimit)
        {
            CreditLimit dbVersion = creditLimitRepository.Find(creditLimit.CreditLimitId);
            if (dbVersion != null)
            {
                UpdateCreditLimitProperties(creditLimit, dbVersion);
                creditLimitRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new CreditLimit();
                SetDocumentProperties(creditLimit, dbVersion);
                creditLimitRepository.Add(dbVersion);
            }
            creditLimitRepository.SaveChanges();
                // To Load the proprties
                return creditLimitRepository.GetCreditLimitWithDetail(dbVersion.CreditLimitId);
        }

       
        /// <summary>
        /// Load All Credit Limits
        /// </summary>
        public IEnumerable<CreditLimit> LoadAll()
        {
            return creditLimitRepository.GetAll();
        }
        #endregion
    }
}
