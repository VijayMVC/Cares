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
    /// Discount Type Service
    /// </summary>
    public class DiscountTypeService : IDiscountTypeService
    {
        #region Private
        private readonly IDiscountTypeRepository discountTypeRepository;
        private readonly IDiscountSubTypeRepository discountSubTypeRepository;

        /// <summary>
        /// Set newly created Discount Type object Properties in case of adding
        /// </summary>
        private void SetDiscountTypeProperties(DiscountType discountType, DiscountType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = discountTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.DiscountTypeCode = discountType.DiscountTypeCode;
            dbVersion.DiscountTypeName = discountType.DiscountTypeName;
            dbVersion.DiscountTypeDescription = discountType.DiscountTypeDescription;
            dbVersion.UserDomainKey = discountTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update  DiscountType object Properties in case of updation
        /// </summary>
        protected void UpdateDiscountTypePropertie(DiscountType discountType, DiscountType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = discountTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DiscountTypeCode = discountType.DiscountTypeCode;
            dbVersion.DiscountTypeName = discountType.DiscountTypeName;
            dbVersion.DiscountTypeDescription = discountType.DiscountTypeDescription;
        }

        /// <summary>
        /// Validation check for deletion
        /// </summary>
        private void ValidateBeforeDeletion(long discountTypeId)
        {
            //  Assocoation with Discount Sub Type check 
            if (discountSubTypeRepository.IsDiscountSubTypeAssociatedWithDiscountType(discountTypeId))
                throw new CaresException(Resources.Pricing.DiscountType.DiscountTypeIsAssociatedWithDiscountSubTypeError); 
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountTypeService(IDiscountTypeRepository discountTypeRepository, IDiscountSubTypeRepository discountSubTypeRepository)
        {
            this.discountTypeRepository = discountTypeRepository;
            this.discountSubTypeRepository = discountSubTypeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Discount Types
        /// </summary>
        public IEnumerable<DiscountType> LoadAll()
        {
            return discountTypeRepository.GetAll();
        }


        /// <summary>
        /// Search Discount Type 
        /// </summary>
        public DiscountTypeSearchRequestResponse SearchDiscountType(DiscountTypeSearchRequest request)
        {
            int rowCount;
            return new DiscountTypeSearchRequestResponse
            {
                DiscountTypes = discountTypeRepository.SearchDiscountType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Discount Type by id
        /// </summary>
        public void DeleteDiscountType(long discountTypeId)
        {
            DiscountType dbversion = discountTypeRepository.Find((int)discountTypeId);
            ValidateBeforeDeletion(discountTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Discount Type with Id {0} not found!", discountTypeId));
            }
            discountTypeRepository.Delete(dbversion);
            discountTypeRepository.SaveChanges();
        }

      /// <summary>
        /// Add /Update Discount Type
        /// </summary>
        public DiscountType SaveDiscountType(DiscountType discountType)
        {
            DiscountType dbVersion = discountTypeRepository.Find((int) discountType.DiscountTypeId);
            //Code Duplication Check
            if (discountTypeRepository.DoesDiscountTypeCodeExist(discountType))
                throw new CaresException(Resources.Pricing.DiscountType.DiscountTypeCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateDiscountTypePropertie(discountType, dbVersion);
                discountTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new DiscountType();
                SetDiscountTypeProperties(discountType, dbVersion);
                discountTypeRepository.Add(dbVersion);
            }
            discountTypeRepository.SaveChanges();
            // To Load the proprties
            return discountTypeRepository.Find((int)dbVersion.DiscountTypeId);
        }

      
        #endregion
    }
}