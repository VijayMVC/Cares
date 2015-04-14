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
    /// Service Items Service
    /// </summary>
    public class ServiceItemService : IServiceItemService
    {
        #region Private

       readonly private IServiceItemRepository serviceItemRepository;
       readonly private IServiceTypeRepository serviceTypeRepository;
       private readonly IRaServiceItemRepository raServiceItemRepository;
       private readonly IServiceRtRepository serviceRtRepository;

        /// <summary>
       /// Set newly created Service Item object Properties in case of adding
        /// </summary>
       private void SetServiceItemProperties(ServiceItem serviceItem, ServiceItem dbVersion)
       {
           dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = serviceItemRepository.LoggedInUserIdentity;
           dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
           dbVersion.ServiceItemCode = serviceItem.ServiceItemCode;
           dbVersion.ServiceItemName = serviceItem.ServiceItemName;
           dbVersion.ServiceItemDescription = serviceItem.ServiceItemDescription;
           dbVersion.ServiceTypeId = serviceItem.ServiceTypeId;
           dbVersion.UserDomainKey = serviceItemRepository.UserDomainKey;
       }

        /// <summary>
       /// update Service Item object Properties in case of updation
        /// </summary>
       private void UpdateServiceItemPropertie(ServiceItem serviceItem, ServiceItem dbVersion)
       {
           dbVersion.RecLastUpdatedBy = serviceItemRepository.LoggedInUserIdentity;
           dbVersion.RecLastUpdatedDt = DateTime.Now;
           dbVersion.RowVersion = dbVersion.RowVersion + 1;
           dbVersion.ServiceItemCode = serviceItem.ServiceItemCode;
           dbVersion.ServiceItemName = serviceItem.ServiceItemName;
           dbVersion.ServiceItemDescription = serviceItem.ServiceItemDescription;
           dbVersion.ServiceTypeId = serviceItem.ServiceTypeId;
       }

       /// <summary>
       /// Dependencies Validation before  deletion
       /// </summary>
       private void ValidateBeforeDeletion(long serviceItemId)
       {
           // Assocoation with R A Service check 
           if (raServiceItemRepository.IsServiceItemAssociatedWithRaServiceItem(serviceItemId))
               throw new CaresException(Resources.Pricing.ServiceItem.ServiceItemIsAssociatedWithRA_ServiceItemError); 

           // Assocoation with Service Rt check 
           if (serviceRtRepository.IsServiceRtAssociatedWithServiceItemValidation(serviceItemId))
               throw new CaresException(Resources.Pricing.ServiceItem.ServiceItemIsAssociatedWithServiceRTError); 

       }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
       public ServiceItemService(IServiceItemRepository serviceItemRepository, IServiceTypeRepository serviceTypeRepository,
           IServiceRtRepository serviceRtRepository,IRaServiceItemRepository raServiceItemRepository)
        {
            this.serviceItemRepository = serviceItemRepository;
            this.serviceTypeRepository = serviceTypeRepository;
            this.raServiceItemRepository = raServiceItemRepository;
            this.serviceRtRepository = serviceRtRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Service Items
        /// </summary>
        public IEnumerable<ServiceItem> GetAll()
        {
            return serviceItemRepository.GetAll();
        }

        // <summary>
        // Load Service Item Base Data
        // </summary>
        public ServiceItemBaseDataResponse LoadServiceItemBaseData()
        {
            return new ServiceItemBaseDataResponse
            {
                ServiceTypes = serviceTypeRepository.GetAll()
            };
        }

        // <summary>
        // Search Service Items
        // </summary>
        public ServiceItemSearchRequestResponse SearchServiceItem(ServiceItemSearchRequest request)
        {
            int rowCount;
            return new ServiceItemSearchRequestResponse
            {
                ServiceItems = serviceItemRepository.SearchServiceItems(request, out rowCount),
                TotalCount = rowCount
            };
        }

        // <summary>
        // Delete Service Item by id
        // </summary>
        public void DeleteServiceItem(long serviceItemId)
        {
            ServiceItem dbversion = serviceItemRepository.Find((int)serviceItemId);
            ValidateBeforeDeletion(serviceItemId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.Pricing.ServiceItem.ServiceItemNotFoundInDatabase));
            }
            serviceItemRepository.Delete(dbversion);
            serviceItemRepository.SaveChanges();
        }

        // <summary>
        // Add / Update Service Item
        // </summary>
        public ServiceItem SaveServiceItem(ServiceItem serviceItem)
        {
            ServiceItem dbVersion = serviceItemRepository.Find(serviceItem.ServiceItemId);
            //Code Duplication Check
            if (serviceItemRepository.CodeDuplicationCheck(serviceItem))
                throw new CaresException(Resources.Pricing.ServiceItem.ServiceItemCodeDuplicationError); 

            if (dbVersion != null)
            {
                UpdateServiceItemPropertie(serviceItem, dbVersion);
                serviceItemRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new ServiceItem();
                SetServiceItemProperties(serviceItem, dbVersion);
                serviceItemRepository.Add(dbVersion);
            }
            serviceItemRepository.SaveChanges();
            // To Load the proprties
            return serviceItemRepository.LoadServiceItemWithDetail(dbVersion.ServiceItemId);
        }
        #endregion
    }
}