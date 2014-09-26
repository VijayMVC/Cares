using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.ExceptionHandling;
using Cares.Implementation.Helpers;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Service Rate Service
    /// </summary>
    public class ServiceRtService : IServiceRtService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IServiceRtMainRepository serviceRtMainRepository;
        private readonly IServiceRtRepository serviceRtRepository;
        private readonly IServiceItemRepository serviceItemRepository;

        #endregion

        #region Constructors
        public ServiceRtService(IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
          IServiceRtMainRepository serviceRtMainRepository, IServiceItemRepository serviceItemRepository, IServiceRtRepository serviceRtRepository)
        {
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.serviceRtMainRepository = serviceRtMainRepository;
            this.serviceItemRepository = serviceItemRepository;
            this.serviceRtRepository = serviceRtRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Tariff Rate Base Data
        /// </summary>
        /// <returns></returns>
        public ServiceRateBaseResponse GetBaseData()
        {
            return new ServiceRateBaseResponse
                   {
                       Operations = operationRepository.GetSalesOperation(),
                       TariffTypes = tariffTypeRepository.GetAll(),
                   };
        }

        /// <summary>
        /// Load Service Rate Mains
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ServiceRateSearchResponse LoadServiceRates(ServiceRateSearchRequest request)
        {
            return serviceRtMainRepository.GetServiceRates(request);
        }

        /// <summary>
        ///Get Service Rate Detail 
        /// </summary>
        /// <returns>Hire Group Detail Response</returns>
        public ServiceRtDetailResponse GetServiceRtDetail(long serviceRtMainId)
        {
            IEnumerable<ServiceItem> serviceItems = serviceItemRepository.GetAll();
            IEnumerable<ServiceRt> serviceRts =
              serviceRtRepository.GetServiceRtByServiceRtMainId(serviceRtMainId);
            // ReSharper disable once SuggestUseVarKeywordEvident
            List<ServiceRtDetailContent> serviceRtDetailList = new List<ServiceRtDetailContent>();

            foreach (var serviceItem in serviceItems)
            {
                ServiceRtDetailContent serviceRtDetail = new ServiceRtDetailContent
                                                         {
                                                             ServiceItemId = serviceItem.ServiceItemId,
                                                             ServiceItemCode = serviceItem.ServiceItemCode,
                                                             ServiceItemName = serviceItem.ServiceItemName,
                                                             ServiceTypeCodeName = serviceItem.ServiceType.ServiceTypeCode + " - " + serviceItem.ServiceType.ServiceTypeName,
                                                             StartDt = DateTime.Now
                                                         };
                serviceRtDetailList.Add(serviceRtDetail);
            }
            foreach (var serviceRtDetailContent in serviceRtDetailList)
            {
                foreach (var serviceRt in serviceRts)
                {
                    if (serviceRt.ServiceItemId == serviceRtDetailContent.ServiceItemId &&
                        serviceRt.ServiceRtMainId == serviceRtMainId)
                    {
                        serviceRtDetailContent.ServiceRtId = serviceRt.ServiceRtId;
                        serviceRtDetailContent.ServiceRate = serviceRt.ServiceRate;
                        serviceRtDetailContent.StartDt = serviceRt.StartDt;
                        serviceRtDetailContent.RevisionNumber = serviceRt.RevisionNumber;
                        serviceRtDetailContent.IsChecked = true;
                    }
                }
            }
            return new ServiceRtDetailResponse
            {
                ServiceRateDetails = serviceRtDetailList,

            };
        }
        /// <summary>
        /// Delete Service Rate
        /// </summary>
        /// <param name="serviceRtMain"></param>
        public void DeleteServiceRate(ServiceRtMain serviceRtMain)
        {
            serviceRtMainRepository.Delete(serviceRtMain);
            serviceRtMainRepository.SaveChanges();
        }

        /// <summary>
        /// Get Service Rate By ID
        /// </summary>
        /// <param name="serviceRtMainId"></param>
        /// <returns></returns>
        public ServiceRtMain FindById(long serviceRtMainId)
        {
            return serviceRtMainRepository.Find(serviceRtMainId);
        }

        /// <summary>
        /// Add/Edit Service Rate
        /// </summary>
        /// <param name="serviceRtMain"></param>
        /// <returns></returns>
        public ServiceRtMainContent SaveInsuranceRate(ServiceRtMain serviceRtMain)
        {
            TariffType tariffType = tariffTypeRepository.Find(long.Parse(serviceRtMain.TariffTypeCode));
            serviceRtMain.TariffTypeCode = tariffType.TariffTypeCode;

            ServiceRtMain serviceRtMainDbVersion = serviceRtMainRepository.Find(serviceRtMain.ServiceRtMainId);
            #region Add
            if (serviceRtMainDbVersion == null)
            {
                ValidateServiceRt(serviceRtMain, true);
                serviceRtMain.UserDomainKey = serviceRtMainRepository.UserDomainKey;
                serviceRtMain.IsActive = true;
                serviceRtMain.IsDeleted = false;
                serviceRtMain.IsPrivate = false;
                serviceRtMain.IsReadOnly = false;
                serviceRtMain.RecCreatedDt = DateTime.Now;
                serviceRtMain.RecLastUpdatedDt = DateTime.Now;
                serviceRtMain.RecCreatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                serviceRtMain.RecLastUpdatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                serviceRtMain.RowVersion = 0;

                //set child (Service Rate in Service Rate Main) properties
                #region Service Rate in Service Rate Main

                if (serviceRtMain.ServiceRts != null)
                {
                    // set properties
                    foreach (ServiceRt item in serviceRtMain.ServiceRts)
                    {
                        item.IsActive = true;
                        item.IsDeleted = false;
                        item.IsPrivate = false;
                        item.IsReadOnly = false;
                        item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedDt = DateTime.Now;
                        item.RecCreatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                        item.RecLastUpdatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                        item.UserDomainKey = serviceRtMainRepository.UserDomainKey;
                    }
                }

                #endregion

                serviceRtMainRepository.Add(serviceRtMain);
                serviceRtMainRepository.SaveChanges();
            }
            #endregion

            #region Edit
            else
            {
                ValidateServiceRt(serviceRtMain, false);
                serviceRtMainDbVersion.RecLastUpdatedDt = DateTime.Now;
                serviceRtMainDbVersion.RecLastUpdatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                serviceRtMainDbVersion.StartDt = serviceRtMain.StartDt;
                //add new Insurance Rate items
                if (serviceRtMain.ServiceRts != null)
                {
                    foreach (ServiceRt serviceRt in serviceRtMain.ServiceRts)
                    {
                        if (
                            serviceRtMainDbVersion.ServiceRts.All(
                                x => x.ServiceRtId != serviceRt.ServiceRtId) ||
                            serviceRt.ServiceRtId == 0)
                        {
                            // set properties
                            serviceRt.IsActive = true;
                            serviceRt.IsDeleted = false;
                            serviceRt.IsPrivate = false;
                            serviceRt.IsReadOnly = false;
                            serviceRt.RecCreatedDt = DateTime.Now;
                            serviceRt.RecLastUpdatedDt = DateTime.Now;
                            serviceRt.RecCreatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                            serviceRt.RecLastUpdatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                            serviceRt.UserDomainKey = serviceRtMainRepository.UserDomainKey;
                            serviceRt.ServiceRtMainId = serviceRtMain.ServiceRtMainId;
                            serviceRtMainDbVersion.ServiceRts.Add(serviceRt);
                        }
                        else
                        {
                            serviceRt.IsActive = true;
                            serviceRt.IsDeleted = false;
                            serviceRt.IsPrivate = false;
                            serviceRt.IsReadOnly = false;
                            serviceRt.RecCreatedDt = DateTime.Now;
                            serviceRt.RecLastUpdatedDt = DateTime.Now;
                            serviceRt.RecCreatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                            serviceRt.RecLastUpdatedBy = serviceRtMainRepository.LoggedInUserIdentity;
                            serviceRt.UserDomainKey = serviceRtMainRepository.UserDomainKey;
                            serviceRt.ServiceRtMainId = serviceRtMain.ServiceRtMainId;
                            long oldRecordId = serviceRt.ServiceRtId;
                            serviceRt.ServiceRtId = 0;
                            serviceRt.RevisionNumber = serviceRt.RevisionNumber + 1;
                            serviceRtRepository.Add(serviceRt);
                            serviceRtRepository.SaveChanges();
                            ServiceRt oldServiceRt = serviceRtRepository.Find(oldRecordId);
                            oldServiceRt.ChildServiceRtId = serviceRt.ServiceRtId;
                            serviceRtRepository.SaveChanges();
                        }

                    }
                }
            }
            serviceRtMainRepository.SaveChanges();

            #endregion

            return new ServiceRtMainContent
            {
                TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                TariffTypeId = tariffType.TariffTypeId,
                OperationId = tariffType.Operation.OperationId,
                OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                ServiceRtMainId = serviceRtMain.ServiceRtMainId,
                ServiceRtMainCode = serviceRtMain.ServiceRtMainCode,
                ServiceRtMainName = serviceRtMain.ServiceRtMainName,
                ServiceRtMainDescription = serviceRtMain.ServiceRtMainDescription,
                StartDt = serviceRtMain.StartDt
            };
        }


        /// <summary>
        /// Validate Servire Rate Main
        /// </summary>
        /// <param name="serviceRtMain"></param>
        /// <param name="addFlag"></param>
        private void ValidateServiceRt(ServiceRtMain serviceRtMain, bool addFlag)
        {
            DateTime oStartDt, serviceStartDt;
            oStartDt = Convert.ToDateTime(serviceRtMain.StartDt);
            if (addFlag)
            {
                //means new Standard Rt is being added
                serviceStartDt = Convert.ToDateTime(serviceRtMain.StartDt);
                if (serviceStartDt.Date < DateTime.Now.Date)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ServiceRate.InvalidStartDate));
                List<ServiceRtMain> oServiceRateMain = serviceRtMainRepository.FindByTariffTypeCode(serviceRtMain.TariffTypeCode).ToList();
                if (oServiceRateMain.Count > 0)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ServiceRate.ServiceRtByTariffExist));
            }
            if (serviceRtMain.ServiceRts != null)
            {
                foreach (var item in serviceRtMain.ServiceRts)
                {
                    serviceStartDt = Convert.ToDateTime(item.StartDt);
                    if (serviceStartDt.Date < DateTime.Now.Date)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ServiceRate.ServRateCurrentDateViolation));
                    if (serviceStartDt.Date < oStartDt.Date)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ServiceRate.ServRateInvalidEffectiveDate));
                }
            }

        }

        /// <summary>
        /// Calculate Charge For Service Item for RA Billing
        /// </summary>
        public RaServiceItem CalculateCharge(DateTime raCreatedDate, DateTime startDtTime, DateTime endDtTime, long serviceItemId, int quantity, Int64 operationId,
            List<TariffType> oTariffTypeList)
        {
            Helpers.PricingStrategy objPs = PricingStrategyFactory.GetPricingStrategy(raCreatedDate, startDtTime, endDtTime, operationId, oTariffTypeList);
            if (objPs == null)
            {
                throw new CaresException("TarrifType not defined", null);
            }

            List<ServiceRt> serviceRts = serviceRtRepository.GetForRaBilling(objPs.TariffType.TariffTypeCode, serviceItemId, raCreatedDate).ToList();

            if (serviceRts.Count == 0)
            {
                throw new CaresException("No ServiceItem rate defined");
            }

            ServiceRt oServiceRate = serviceRts[0];

            return objPs.CalculateRAServiceItemCharge(startDtTime, endDtTime, quantity, oServiceRate);
        }

        #endregion
    }
}
