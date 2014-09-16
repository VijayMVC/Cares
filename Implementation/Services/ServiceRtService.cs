using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.ExceptionHandling;
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
        ///// <summary>
        ///// Add Insurance Rate
        ///// </summary>
        ///// <param name="insuranceRtMain"></param>
        ///// <returns></returns>
        //public InsuranceRtMainContent SaveInsuranceRate(InsuranceRtMain insuranceRtMain)
        //{
        //    TariffType tariffType = tariffTypeRepository.Find(long.Parse(insuranceRtMain.TariffTypeCode));
        //    insuranceRtMain.TariffTypeCode = tariffType.TariffTypeCode;

        //    InsuranceRtMain insuranceRtMainDbVersion = insuranceRtMainRepository.Find(insuranceRtMain.InsuranceRtMainId);
        //    #region Add
        //    if (insuranceRtMainDbVersion == null)
        //    {
        //        ValidateInsuranceRate(insuranceRtMain, true);
        //        insuranceRtMain.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
        //        insuranceRtMain.IsActive = true;
        //        insuranceRtMain.IsDeleted = false;
        //        insuranceRtMain.IsPrivate = false;
        //        insuranceRtMain.IsReadOnly = false;
        //        insuranceRtMain.RecCreatedDt = DateTime.Now;
        //        insuranceRtMain.RecLastUpdatedDt = DateTime.Now;
        //        insuranceRtMain.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //        insuranceRtMain.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //        insuranceRtMain.RowVersion = 0;
        //        insuranceRtMainRepository.Add(insuranceRtMain);
        //        //set child (Insurance Rate in Insurance Rate Main) properties

        //        #region Insurance Rate in Insurance Rate Main

        //        if (insuranceRtMain.InsuranceRates != null)
        //        {
        //            // set properties
        //            foreach (InsuranceRt item in insuranceRtMain.InsuranceRates)
        //            {
        //                item.IsActive = true;
        //                item.IsDeleted = false;
        //                item.IsPrivate = false;
        //                item.IsReadOnly = false;
        //                item.RecCreatedDt = DateTime.Now;
        //                item.RecLastUpdatedDt = DateTime.Now;
        //                item.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                item.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                item.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
        //            }
        //        }

        //        #endregion

        //        insuranceRtMainRepository.Add(insuranceRtMain);
        //        insuranceRtMainRepository.SaveChanges();
        //    }
        //    #endregion
        //    #region Edit
        //    else
        //    {
        //        ValidateInsuranceRate(insuranceRtMain,false);
        //        insuranceRtMainDbVersion.RecLastUpdatedDt = DateTime.Now;
        //        insuranceRtMainDbVersion.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //        insuranceRtMainDbVersion.StartDt = insuranceRtMain.StartDt;

        //        //add new Insurance Rate items
        //        if (insuranceRtMain.InsuranceRates != null)
        //        {
        //            foreach (InsuranceRt insuranceRt in insuranceRtMain.InsuranceRates)
        //            {
        //                if (
        //                    insuranceRtMainDbVersion.InsuranceRates.All(
        //                        x => x.InsuranceRtId != insuranceRt.InsuranceRtId) ||
        //                    insuranceRt.InsuranceRtId == 0)
        //                {
        //                    // set properties
        //                    insuranceRt.IsActive = true;
        //                    insuranceRt.IsDeleted = false;
        //                    insuranceRt.IsPrivate = false;
        //                    insuranceRt.IsReadOnly = false;
        //                    insuranceRt.RecCreatedDt = DateTime.Now;
        //                    insuranceRt.RecLastUpdatedDt = DateTime.Now;
        //                    insuranceRt.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                    insuranceRt.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                    insuranceRt.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
        //                    insuranceRt.InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId;
        //                    insuranceRtMainDbVersion.InsuranceRates.Add(insuranceRt);
        //                }
        //                else
        //                {
        //                    insuranceRt.IsActive = true;
        //                    insuranceRt.IsDeleted = false;
        //                    insuranceRt.IsPrivate = false;
        //                    insuranceRt.IsReadOnly = false;
        //                    insuranceRt.RecCreatedDt = DateTime.Now;
        //                    insuranceRt.RecLastUpdatedDt = DateTime.Now;
        //                    insuranceRt.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                    insuranceRt.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
        //                    insuranceRt.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
        //                    insuranceRt.InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId;
        //                    long oldRecordId = insuranceRt.InsuranceRtId;
        //                    insuranceRt.InsuranceRtId = 0;
        //                    insuranceRt.RevisionNumber = insuranceRt.RevisionNumber + 1;
        //                    insuranceRtRepository.Add(insuranceRt);
        //                    insuranceRtRepository.SaveChanges();
        //                    InsuranceRt oldInsuranceRt = insuranceRtRepository.Find(oldRecordId);
        //                    oldInsuranceRt.ChildInsuranceRtId = insuranceRt.InsuranceRtId;
        //                    insuranceRtRepository.SaveChanges();
        //                }

        //            }
        //        }
        //    }

        //    #endregion
        //    insuranceRtMainRepository.SaveChanges();
        //    return new InsuranceRtMainContent
        //    {
        //        TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
        //        TariffTypeId = tariffType.TariffTypeId,
        //        OperationId = tariffType.Operation.OperationId,
        //        OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
        //        InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId,
        //        InsuranceRtMainCode = insuranceRtMain.InsuranceRtMainCode,
        //        InsuranceRtName = insuranceRtMain.InsuranceRtMainCode,
        //        InsuranceRtMainDescription = insuranceRtMain.InsuranceRtMainDescription,
        //        StartDt = insuranceRtMain.StartDt
        //    };
        //}

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
        #endregion
    }
}
