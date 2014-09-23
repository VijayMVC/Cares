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
    /// Region Service
    /// </summary>
    public class DiscountSubTypeService : IDiscountSubTypeService
    {
        #region Private
        private readonly IDiscountSubTypeRepository discountSubTypeRepository;
        private readonly IDiscountTypeRepository discountTypeRepository;
        /// <summary>
        /// Set newly created Region object Properties in case of adding
        /// </summary>
        private void SetDiscountSubTypeProperties(DiscountSubType discountSubType, DiscountSubType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = discountSubTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.DiscountSubTypeCode = discountSubType.DiscountSubTypeCode;
            dbVersion.DiscountSubTypeName = discountSubType.DiscountSubTypeName;
            dbVersion.DiscountSubTypeDescription = discountSubType.DiscountSubTypeDescription;
            dbVersion.DiscountTypeId = discountSubType.DiscountTypeId;
            dbVersion.UserDomainKey = discountSubTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Discount Sub Type object Properties in case of updation
        /// </summary>
        protected void UpdateDiscountSubTypePropertie(DiscountSubType discountSubType, DiscountSubType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = discountSubTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DiscountSubTypeCode = discountSubType.DiscountSubTypeCode;
            dbVersion.DiscountSubTypeName = discountSubType.DiscountSubTypeName;
            dbVersion.DiscountSubTypeDescription = discountSubType.DiscountSubTypeDescription;
            dbVersion.DiscountTypeId = discountSubType.DiscountTypeId;
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountSubTypeService(IDiscountSubTypeRepository discountSubTypeRepository, IDiscountTypeRepository discountTypeRepository)
        {
            this.discountSubTypeRepository = discountSubTypeRepository;
            this.discountTypeRepository = discountTypeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Discount Sub Types
        /// </summary>
        public IEnumerable<DiscountSubType> LoadAll()
        {
            return discountSubTypeRepository.GetAll();
        }

        /// <summary>
        /// Load Discount Sub Type Base Data
        /// </summary>
        public DiscountSubTypeBaseDataResponse LoadDiscountSubTypeBaseData()
        {
            return new DiscountSubTypeBaseDataResponse
            {
                DiscountTypes = discountTypeRepository.GetAll()
            };
        }

        /// <summary>
        /// Discount Sub Type Search
        /// </summary>
        public DiscountSubTypeSearchRequestResponse SearchDiscountSubType(DiscountSubTypeSearchRequest request)
        {
            int rowCount;
            return new DiscountSubTypeSearchRequestResponse
            {
                DiscountSubTypes = discountSubTypeRepository.SearchDiscountSubType(request,out rowCount)
            };
        }

        /// <summary>
        /// Delete Discount Sub Type by id
        /// </summary>
        public void DeleteDiscountSubType(long discountSubTypeId)
        {
            DiscountSubType dbversion = discountSubTypeRepository.Find((int)discountSubTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Discount Sub Type with Id {0} not found!", discountSubTypeId));
            }
            discountSubTypeRepository.Delete(dbversion);
            discountSubTypeRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Discount Sub Type
        /// </summary>
        public DiscountSubType SaveDiscountSubType(DiscountSubType discountSubType)
        {
            DiscountSubType dbVersion = discountSubTypeRepository.Find((int) discountSubType.DiscountSubTypeId);
            //Code Duplication Check
            if (discountSubTypeRepository.DoesDiscountSubTypeCodeExist(discountSubType))
                throw new CaresException(Resources.Pricing.DiscountSubType.DiscountSubTypeCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateDiscountSubTypePropertie(discountSubType, dbVersion);
                discountSubTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion=new DiscountSubType();
                SetDiscountSubTypeProperties(discountSubType, dbVersion);
                discountSubTypeRepository.Add(dbVersion);
            }
            discountSubTypeRepository.SaveChanges();
            // To Load the proprties
            return discountSubTypeRepository.Find((int) dbVersion.DiscountSubTypeId);
        }

      
        #endregion
    }
}