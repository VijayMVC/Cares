using System.Collections.Generic;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Discount Type Service
    /// </summary>
    public class ServiceTypeService : IServiceTypeService
    {
        #region Private
        private readonly IServiceTypeRepository serviceTypeRepository;
        private readonly IServiceItemRepository serviceItemRepository;

        /// <summary>
        /// Set newly created Service Type object Properties in case of adding
        /// </summary>
        private void SetServiceTypeProperties(ServiceType serviceType, ServiceType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = serviceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.ServiceTypeCode = serviceType.ServiceTypeCode;
            dbVersion.ServiceTypeName = serviceType.ServiceTypeName;
            dbVersion.ServiceTypeDescription = serviceType.ServiceTypeDescription;
            dbVersion.UserDomainKey = serviceTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Service Type object Properties in case of updation
        /// </summary>
        protected void UpdateServiceTypePropertie(ServiceType serviceType, ServiceType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = serviceTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.ServiceTypeCode = serviceType.ServiceTypeCode;
            dbVersion.ServiceTypeName = serviceType.ServiceTypeName;
            dbVersion.ServiceTypeDescription = serviceType.ServiceTypeDescription;
        }

        /// <summary>
        /// Validation check for deletion
        /// </summary>
        private void ValidateBeforeDeletion(long discountTypeId)
        {
            //  Assocoation with Service Item  check 
            if (serviceItemRepository.IsServiceItemAssociatedWithServiceType(discountTypeId))
                throw new CaresException(Resources.Pricing.ServiceType.ServiceTypeIsAssociatedWithServiceItemError);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository, IServiceItemRepository serviceItemRepository)
        {
            this.serviceTypeRepository = serviceTypeRepository;
            this.serviceItemRepository = serviceItemRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Service Types
        /// </summary>
        public IEnumerable<ServiceType> LoadAll()
        {
            return serviceTypeRepository.GetAll();
        }


        /// <summary>
        /// Search Service Type 
        /// </summary>
        public ServiceTypeSearchRequestResponse SearchServiceType(ServiceTypeSearchRequest request)
        {
            int rowCount;
            return new ServiceTypeSearchRequestResponse
            {
                ServiceTypes = serviceTypeRepository.SearchServiceType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Service Type by id
        /// </summary>
        public void DeleteServiceType(long serviceTypeId)
        {
            ServiceType dbversion = serviceTypeRepository.Find((int)serviceTypeId);
            ValidateBeforeDeletion(serviceTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(Resources.Pricing.ServiceType.ServiceTypeNotFoundInDatabase);
            }
            serviceTypeRepository.Delete(dbversion);
            serviceTypeRepository.SaveChanges();
        }

        /// <summary>
        /// Add / Update Service Type
        /// </summary>
        public ServiceType SaveServiceType(ServiceType serviceType)
        {
            ServiceType dbVersion = serviceTypeRepository.Find((int)serviceType.ServiceTypeId);
            //Code Duplication Check
            if (serviceTypeRepository.ServiceTypeCodeDuplicationCheck(serviceType))
                throw new CaresException(Resources.Pricing.ServiceType.ServiceTypeCodeDupliationError);

            if (dbVersion != null)
            {
                UpdateServiceTypePropertie(serviceType, dbVersion);
                serviceTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new ServiceType();
                SetServiceTypeProperties(serviceType, dbVersion);
                serviceTypeRepository.Add(dbVersion);
            }
            serviceTypeRepository.SaveChanges();
            // To Load the proprties
            return serviceTypeRepository.Find(dbVersion.ServiceTypeId);
        }

      
        #endregion
    }
}