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
    /// Insurance Rate Service
    /// </summary>
    public class InsuranceRateService : IInsuranceRateService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IInsuranceRtMainRepository insuranceRtMainRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IInsuranceRtRepository insuranceRtRepository;
        private readonly IInsuranceTypeRepository insuranceTypeRepository;

        #endregion

        #region Constructors

        public InsuranceRateService(IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
            IInsuranceRtMainRepository insuranceRtMainRepository, IHireGroupDetailRepository hireGroupDetailRepository,
            IInsuranceRtRepository insuranceRtRepository, IInsuranceTypeRepository insuranceTypeRepository)
        {
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.insuranceRtMainRepository = insuranceRtMainRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.insuranceRtRepository = insuranceRtRepository;
            this.insuranceTypeRepository = insuranceTypeRepository;
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

        /// <summary>
        /// Load Insurance Rates
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public InsuranceRateSearchResponse LoadInsuranceRates(InsuranceRateSearchRequest request)
        {
            return insuranceRtMainRepository.GetInsuranceRates(request);
        }

        /// <summary>
        ///Get Hire Group Detail List
        /// </summary>
        /// <returns>Hire Group Detail Response</returns>
        public InsuranceRtDetailResponse GetInsuranceRtDetail(long insuranceRtMainId)
        {
            IEnumerable<HireGroupDetail> hireGroupDetails = hireGroupDetailRepository.GetAll();
            IEnumerable<InsuranceType> insuranceTypes = insuranceTypeRepository.GetAll();
            IEnumerable<InsuranceRt> insuranceRts =
                insuranceRtRepository.GetInsuranceRtByInsuranceRtMainId(insuranceRtMainId);
            // ReSharper disable once SuggestUseVarKeywordEvident
            List<InsuranceRtDetailContent> insuranceRtDetailList = new List<InsuranceRtDetailContent>();
            foreach (var insuranceType in insuranceTypes)
            {
                foreach (var hireGroupDetail in hireGroupDetails)
                {
                    var insuranceRtDetailContent = new InsuranceRtDetailContent();
                    insuranceRtDetailContent.InsuranceTypeId = insuranceType.InsuranceTypeId;
                    insuranceRtDetailContent.InsuranceTypeCodeName = insuranceType.InsuranceTypeCode + " - " +
                                                                     insuranceType.InsuranceTypeName;
                    insuranceRtDetailContent.HireGroupDetailId = hireGroupDetail.HireGroupDetailId;
                    insuranceRtDetailContent.ModelYear = hireGroupDetail.ModelYear;
                    insuranceRtDetailContent.HireGroupDetailCodeName = hireGroupDetail.HireGroup.HireGroupCode + " - " + hireGroupDetail.HireGroup.HireGroupName;
                    insuranceRtDetailContent.VehicleCategoryCodeName = hireGroupDetail.VehicleCategory.VehicleCategoryCode + " - " + hireGroupDetail.VehicleCategory.VehicleCategoryName;
                    insuranceRtDetailContent.VehicleMakeCodeName = hireGroupDetail.VehicleMake.VehicleMakeCode + " - " + hireGroupDetail.VehicleMake.VehicleMakeName;
                    insuranceRtDetailContent.VehicleModelCodeName = hireGroupDetail.VehicleModel.VehicleModelCode + " - " + hireGroupDetail.VehicleModel.VehicleModelName;
                    insuranceRtDetailList.Add(insuranceRtDetailContent);

                }

            }
            foreach (var insuranceRt in insuranceRts)
            {
                foreach (var insuranceRtDetailContent in insuranceRtDetailList)
                {
                    if (insuranceRtDetailContent.InsuranceTypeId == insuranceRt.InsuranceTypeId &&
                        insuranceRtDetailContent.HireGroupDetailId == insuranceRt.HireGroupDetailId)
                    {
                        insuranceRtDetailContent.InsuranceRtId = insuranceRt.InsuranceRtId;
                        insuranceRtDetailContent.InsuranceRtMainId = insuranceRt.InsuranceRtMainId;
                        insuranceRtDetailContent.InsuranceRate = insuranceRt.InsuranceRate;
                        insuranceRtDetailContent.StartDate = insuranceRt.StartDt;
                        insuranceRtDetailContent.IsChecked = true;
                        insuranceRtDetailContent.RevisionNumber = insuranceRt.RevisionNumber;

                    }
                }

            }
            return new InsuranceRtDetailResponse
            {
                InsuranceRateDetails = insuranceRtDetailList,

            };
        }

        /// <summary>
        /// Add/Edit Insurance Rate
        /// </summary>
        /// <param name="insuranceRtMain"></param>
        /// <returns></returns>
        public InsuranceRtMainContent SaveInsuranceRate(InsuranceRtMain insuranceRtMain)
        {
            //Code Duplication Check
            if (insuranceRtMainRepository.IsInsuranceRtMainCodeExists(insuranceRtMain.InsuranceRtMainCode,
              insuranceRtMain.InsuranceRtMainId))
            {
                throw new CaresException(Resources.Tariff.InsuranceRate.CodeDuplicationError);
            }

            TariffType tariffType = tariffTypeRepository.Find(long.Parse(insuranceRtMain.TariffTypeCode));
            insuranceRtMain.TariffTypeCode = tariffType.TariffTypeCode;

            InsuranceRtMain insuranceRtMainDbVersion = insuranceRtMainRepository.Find(insuranceRtMain.InsuranceRtMainId);
            #region Add
            if (insuranceRtMainDbVersion == null)
            {
                ValidateInsuranceRate(insuranceRtMain, true);
                insuranceRtMain.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
                insuranceRtMain.IsActive = true;
                insuranceRtMain.IsDeleted = false;
                insuranceRtMain.IsPrivate = false;
                insuranceRtMain.IsReadOnly = false;
                insuranceRtMain.RecCreatedDt = DateTime.Now;
                insuranceRtMain.RecLastUpdatedDt = DateTime.Now;
                insuranceRtMain.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                insuranceRtMain.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                insuranceRtMain.RowVersion = 0;
                //insuranceRtMainRepository.Add(insuranceRtMain);
                //set child (Insurance Rate in Insurance Rate Main) properties

                #region Insurance Rate in Insurance Rate Main

                if (insuranceRtMain.InsuranceRates != null)
                {
                    // set properties
                    foreach (InsuranceRt item in insuranceRtMain.InsuranceRates)
                    {
                        item.IsActive = true;
                        item.IsDeleted = false;
                        item.IsPrivate = false;
                        item.IsReadOnly = false;
                        item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedDt = DateTime.Now;
                        item.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                        item.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                        item.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
                    }
                }

                #endregion

                insuranceRtMainRepository.Add(insuranceRtMain);
                insuranceRtMainRepository.SaveChanges();
            }
            #endregion
            #region Edit
            else
            {
                ValidateInsuranceRate(insuranceRtMain, false);
                insuranceRtMainDbVersion.RecLastUpdatedDt = DateTime.Now;
                insuranceRtMainDbVersion.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                insuranceRtMainDbVersion.StartDt = insuranceRtMain.StartDt;

                //add new Insurance Rate items
                if (insuranceRtMain.InsuranceRates != null)
                {
                    foreach (InsuranceRt insuranceRt in insuranceRtMain.InsuranceRates)
                    {
                        if (
                            insuranceRtMainDbVersion.InsuranceRates.All(
                                x => x.InsuranceRtId != insuranceRt.InsuranceRtId) ||
                            insuranceRt.InsuranceRtId == 0)
                        {
                            // set properties
                            insuranceRt.IsActive = true;
                            insuranceRt.IsDeleted = false;
                            insuranceRt.IsPrivate = false;
                            insuranceRt.IsReadOnly = false;
                            insuranceRt.RecCreatedDt = DateTime.Now;
                            insuranceRt.RecLastUpdatedDt = DateTime.Now;
                            insuranceRt.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                            insuranceRt.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                            insuranceRt.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
                            insuranceRt.InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId;
                            insuranceRtMainDbVersion.InsuranceRates.Add(insuranceRt);
                        }
                        else
                        {
                            insuranceRt.IsActive = true;
                            insuranceRt.IsDeleted = false;
                            insuranceRt.IsPrivate = false;
                            insuranceRt.IsReadOnly = false;
                            insuranceRt.RecCreatedDt = DateTime.Now;
                            insuranceRt.RecLastUpdatedDt = DateTime.Now;
                            insuranceRt.RecCreatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                            insuranceRt.RecLastUpdatedBy = insuranceRtMainRepository.LoggedInUserIdentity;
                            insuranceRt.UserDomainKey = insuranceRtMainRepository.UserDomainKey;
                            insuranceRt.InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId;
                            long oldRecordId = insuranceRt.InsuranceRtId;
                            insuranceRt.InsuranceRtId = 0;
                            insuranceRt.RevisionNumber = insuranceRt.RevisionNumber + 1;
                            insuranceRtRepository.Add(insuranceRt);
                            insuranceRtRepository.SaveChanges();
                            InsuranceRt oldInsuranceRt = insuranceRtRepository.Find(oldRecordId);
                            oldInsuranceRt.ChildInsuranceRtId = insuranceRt.InsuranceRtId;
                            insuranceRtRepository.SaveChanges();
                        }

                    }
                }
            }

            #endregion
            insuranceRtMainRepository.SaveChanges();
            return new InsuranceRtMainContent
            {
                TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                TariffTypeId = tariffType.TariffTypeId,
                OperationId = tariffType.Operation.OperationId,
                OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId,
                InsuranceRtMainCode = insuranceRtMain.InsuranceRtMainCode,
                InsuranceRtName = insuranceRtMain.InsuranceRtMainCode,
                InsuranceRtMainDescription = insuranceRtMain.InsuranceRtMainDescription,
                StartDt = insuranceRtMain.StartDt
            };
        }

        /// <summary>
        /// Delete Insurance Rate
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        public void DeleteInsuranceRate(long insuranceRtMainId)
        {
            insuranceRtMainRepository.Delete(insuranceRtMainRepository.Find((insuranceRtMainId)));
            insuranceRtMainRepository.SaveChanges();
        }

        /// <summary>
        /// Find Insurance Rate Main By Id
        /// </summary>
        /// <param name="insuranceRtMainId">Insurance Rate Main Id</param>
        /// <returns></returns>
        public InsuranceRtMain FindById(long insuranceRtMainId)
        {
            return insuranceRtMainRepository.Find(insuranceRtMainId);
        }

        /// <summary>
        /// Calculate Insurance Charge for Ra Billing
        /// </summary>
        public RaHireGroupInsurance CalculateCharge(DateTime raRecCreatedDate, DateTime stDate, DateTime eDate, long operationId,
            long hireGroupDetailId, short insuranceTypeId, List<TariffType> oTariffTypeList)
        {
            Helpers.PricingStrategy objPs = PricingStrategyFactory.GetPricingStrategy(raRecCreatedDate, stDate, eDate, operationId, oTariffTypeList);
            if (objPs == null)
            {
                throw new CaresException(Resources.RentalAgreement.RentalAgreement.TariffTypeNotDefinedForHireGroupInsurance, null);
            }

            List<InsuranceRt> insuranceRts = insuranceRtRepository.
                GetForRaBilling(objPs.TariffType.TariffTypeCode, hireGroupDetailId, insuranceTypeId, raRecCreatedDate).ToList();

            if (insuranceRts.Count == 0)
            {
                throw new CaresException(Resources.RentalAgreement.RentalAgreement.InsuranceRateNotDefinedForHireGroupInsurance);
            }

            InsuranceRt oInsRate = insuranceRts[0];

            return objPs.CalculateInsuranceCharge(stDate, eDate, oInsRate);
        }

        /// <summary>
        /// Get All For RA
        /// </summary>
        public IEnumerable<InsuranceRt> GetAllForRa()
        {
            return insuranceRtRepository.GetAllForRa();
        }

        /// <summary>
        /// Validate Insurance Rate Main
        /// </summary>
        /// <param name="insuranceRtMain"></param>
        /// <param name="addFlag"></param>
        private void ValidateInsuranceRate(InsuranceRtMain insuranceRtMain, bool addFlag)
        {
            DateTime oStartDt, insRtStartDate;
            oStartDt = Convert.ToDateTime(insuranceRtMain.StartDt);
            if (addFlag)
            {
                //means new Standard Rt is being added
                insRtStartDate = Convert.ToDateTime(insuranceRtMain.StartDt);
                if (insRtStartDate.Date < DateTime.Now.Date)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.InsuranceRate.InvalidStartDate));
                List<InsuranceRtMain> oStRateMain = insuranceRtMainRepository.FindByTariffTypeCode(insuranceRtMain.TariffTypeCode).ToList();
                if (oStRateMain.Count > 0)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.InsuranceRate.InsuranceRtByTariffExist));

            }
            if (insuranceRtMain.InsuranceRates != null)
            {
                foreach (var item in insuranceRtMain.InsuranceRates)
                {
                    insRtStartDate = Convert.ToDateTime(item.StartDt);
                    if (insRtStartDate.Date < DateTime.Now.Date)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.InsuranceRate.InsRateCurrentDateViolation));
                    if (insRtStartDate.Date < oStartDt.Date)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.InsuranceRate.InsuranceRateInvalidEffectiveDate));
                }
            }
        }
        #endregion
    }
}
