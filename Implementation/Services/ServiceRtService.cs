using System;
using System.Collections.Generic;
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
    public class ServiceRtService:IServiceRtService
    {
         #region Private
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IServiceRtMainRepository serviceRtMainRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IServiceRtService serviceRtService;
        private readonly IServiceTypeRepository serviceTypeRepository;

        #endregion

        #region Constructors

        public ServiceRtService(IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
            IServiceRtMainRepository serviceRtMainRepository, IHireGroupDetailRepository hireGroupDetailRepository,
            IServiceRtService serviceRtService, IServiceTypeRepository serviceTypeRepository)
        {
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.serviceRtMainRepository = serviceRtMainRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.serviceRtService = serviceRtService;
            this.serviceTypeRepository = serviceTypeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Tariff Rate Base Data
        /// </summary>
        /// <returns></returns>
        public InsuranceRateBaseResponse GetBaseData()
        {
            return new InsuranceRateBaseResponse
                   {
                       Operations = operationRepository.GetSalesOperation(),
                       TariffTypes = tariffTypeRepository.GetAll(),
                   };
        }

        //public InsuranceRateSearchResponse LoadInsuranceRates(InsuranceRateSearchRequest request)
        //{
        //    return insuranceRtMainRepository.GetInsuranceRates(request);
        //}
        ///// <summary>
        /////Get Hire Group Detail List
        ///// </summary>
        ///// <returns>Hire Group Detail Response</returns>
        //public InsuranceRtDetailResponse GetInsuranceRtDetail(long insuranceRtMainId)
        //{
        //    IEnumerable<HireGroupDetail> hireGroupDetails = hireGroupDetailRepository.GetAll();
        //    IEnumerable<InsuranceType> insuranceTypes = insuranceTypeRepository.GetAll();
        //    IEnumerable<InsuranceRt> insuranceRts =
        //        insuranceRtRepository.GetInsuranceRtByInsuranceRtMainId(insuranceRtMainId);
        //    // ReSharper disable once SuggestUseVarKeywordEvident
        //    List<InsuranceRtDetailContent> insuranceRtDetailList = new List<InsuranceRtDetailContent>();
        //    foreach (var insuranceType in insuranceTypes)
        //    {
        //        foreach (var hireGroupDetail in hireGroupDetails)
        //        {
        //            var insuranceRtDetailContent = new InsuranceRtDetailContent();
        //            insuranceRtDetailContent.InsuranceTypeId = insuranceType.InsuranceTypeId;
        //            insuranceRtDetailContent.InsuranceTypeCodeName = insuranceType.InsuranceTypeCode + " - " +
        //                                                             insuranceType.InsuranceTypeName;
        //            insuranceRtDetailContent.HireGroupDetailId = hireGroupDetail.HireGroupDetailId;
        //            insuranceRtDetailContent.ModelYear = hireGroupDetail.ModelYear;
        //            insuranceRtDetailContent.HireGroupDetailCodeName = hireGroupDetail.HireGroup.HireGroupCode + " - " + hireGroupDetail.HireGroup.HireGroupName;
        //            insuranceRtDetailContent.VehicleCategoryCodeName = hireGroupDetail.VehicleCategory.VehicleCategoryCode + " - " + hireGroupDetail.VehicleCategory.VehicleCategoryName;
        //            insuranceRtDetailContent.VehicleMakeCodeName = hireGroupDetail.VehicleMake.VehicleMakeCode + " - " + hireGroupDetail.VehicleMake.VehicleMakeName;
        //            insuranceRtDetailContent.VehicleModelCodeName = hireGroupDetail.VehicleModel.VehicleModelCode + " - " + hireGroupDetail.VehicleModel.VehicleModelName;
        //            insuranceRtDetailList.Add(insuranceRtDetailContent);

        //        }

        //    }
        //    foreach (var insuranceRt in insuranceRts)
        //    {
        //        foreach (var insuranceRtDetailContent in insuranceRtDetailList)
        //        {
        //            if (insuranceRtDetailContent.InsuranceTypeId == insuranceRt.InsuranceTypeId &&
        //                insuranceRtDetailContent.HireGroupDetailId == insuranceRt.HireGroupDetailId)
        //            {
        //                insuranceRtDetailContent.InsuranceRtId = insuranceRt.InsuranceRtId;
        //                insuranceRtDetailContent.InsuranceRtMainId = insuranceRt.InsuranceRtMainId;
        //                insuranceRtDetailContent.InsuranceRate = insuranceRt.InsuranceRate;
        //                insuranceRtDetailContent.StartDate = insuranceRt.StartDt;
        //                insuranceRtDetailContent.IsChecked = true;
        //                insuranceRtDetailContent.RevisionNumber = insuranceRt.RevisionNumber;

        //            }
        //        }

        //    }
        //    return new InsuranceRtDetailResponse
        //    {
        //        InsuranceRateDetails = insuranceRtDetailList,

        //    };
        //}
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

        ///// <summary>
        ///// Delete Insurance Rate
        ///// </summary>
        ///// <param name="insuranceRtMain"></param>
        //public void DeleteInsuranceRate(InsuranceRtMain insuranceRtMain)
        //{
        //    insuranceRtMainRepository.Delete(insuranceRtMain);
        //    insuranceRtMainRepository.SaveChanges();
        //}

        //public InsuranceRtMain FindById(long insuranceRtMainId)
        //{
        //    return insuranceRtMainRepository.Find(insuranceRtMainId);
        //}

        //private void ValidateInsuranceRate(InsuranceRtMain insuranceRtMain, bool addFlag)
        //{
        //    DateTime oStartDt, insRtStartDate;
        //    oStartDt = Convert.ToDateTime(insuranceRtMain.StartDt);
        //    if (addFlag)
        //    {
        //        //means new Standard Rt is being added
        //        insRtStartDate = Convert.ToDateTime(insuranceRtMain.StartDt);
        //        if (insRtStartDate.Date < DateTime.Now.Date)
        //            throw new CaresException("Start Effective Date must be a current or future date.");
        //        List<InsuranceRtMain> oStRateMain = insuranceRtMainRepository.FindByTariffTypeCode(insuranceRtMain.TariffTypeCode).ToList();
        //        if (oStRateMain.Count > 0)
        //            throw new CaresException("Insurance Rate for the selected tariff type already exist.");

        //    }
        //    if (insuranceRtMain.InsuranceRates != null)
        //    {
        //        foreach (var item in insuranceRtMain.InsuranceRates)
        //        {
        //            insRtStartDate = Convert.ToDateTime(item.StartDt);
        //            if (insRtStartDate.Date < DateTime.Now.Date)
        //                throw new CaresException("Start Date for Insurance Item Rate must be a current or future date.");
        //            if (insRtStartDate.Date < oStartDt.Date)
        //                throw new CaresException("Start Date for Insurance Item Rate must be greater than their Start Effective Date.");
        //        }
        //    }
        //}
        #endregion
    }
}
