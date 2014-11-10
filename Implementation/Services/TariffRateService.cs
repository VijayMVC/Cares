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
    /// Tariff Rate Service
    /// </summary>
    public sealed class TariffRateService : ITariffRateService
    {
        #region Private

        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        private readonly IHireGroupRepository hireGroupRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IStandardRateMainRepository standardRateMainRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IStandardRateRepository standardRateRepository;

        #endregion

        #region Constructors

        public TariffRateService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository,
            IOperationRepository operationRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository,
            IVehicleCategoryRepository vehicleCategoryRepository,
            IHireGroupRepository hireGroupRepository, ITariffTypeRepository tariffTypeRepository,
            IStandardRateMainRepository standardRateMainRepository,
            IHireGroupDetailRepository hireGroupDetailRepository, IStandardRateRepository standardRateRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.hireGroupRepository = hireGroupRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.standardRateMainRepository = standardRateMainRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.standardRateRepository = standardRateRepository;


        }

        #endregion

        #region Public

        /// <summary>
        /// Get Tariff Rate Base Data
        /// </summary>
        /// <returns></returns>
        public TariffRateBaseResponse GetBaseData()
        {
            return new TariffRateBaseResponse
                   {
                       Companies = companyRepository.GetAll(),
                       Departments = departmentRepository.GetAll(),
                       Operations = operationRepository.GetAll(),
                       HireGroups = hireGroupRepository.GetAll(),
                       VehicleModels = vehicleModelRepository.GetAll(),
                       VehicleMakes = vehicleMakeRepository.GetAll(),
                       VehicleCategories = vehicleCategoryRepository.GetAll(),
                       TariffTypes = tariffTypeRepository.GetAll(),
                   };
        }

        /// <summary>
        /// Get Stanadrd Rate Main
        /// </summary>
        /// <param name="tariffRateRequest"></param>
        /// <returns></returns>
        public TariffRateResponse LoadTariffRates(TariffRateSearchRequest tariffRateRequest)
        {
            return standardRateMainRepository.GetTariffRates(tariffRateRequest);
        }

        /// <summary>
        ///Get Hire Group Detail List
        /// </summary>
        /// <returns>Hire Group Detail Response</returns>
        public HireGroupDetailResponse GetHireGroupDetailsForTariffRate(long standardRtMainId)
        {
            IEnumerable<HireGroupDetail> hireGroupDetails = hireGroupDetailRepository.GetHireGroupDetailsForTariffRate();
            IEnumerable<StandardRate> standardRates =
                standardRateRepository.GetStandardRateForTariffRate(standardRtMainId);
            return new HireGroupDetailResponse
                   {
                       HireGroupDetails = hireGroupDetails,
                       StandardRates = standardRates,
                       StandardRateId = standardRtMainId
                   };
        }

        /// <summary>
        /// Find Standard Rate Main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StandardRateMain Find(long id)
        {
            return standardRateMainRepository.Find(id);
        }

        /// <summary>
        /// Add Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public TariffRateContent SaveTariffRate(StandardRateMain standardRateMain)
        {
            TariffType tariffType = tariffTypeRepository.Find(long.Parse(standardRateMain.TariffTypeCode));
            standardRateMain.TariffTypeCode = tariffType.TariffTypeCode;

            #region Add
            if (standardRateMain.StandardRtMainId == 0)
            {
                List<StandardRateMain> standardRateMains = standardRateMainRepository.GetByStandardRateMainCode(standardRateMain.StandardRtMainCode).ToList();
                if (standardRateMains.Count() > 0)
                    throw new CaresException(Resources.Tariff.TariffRate.CodeDuplication);

                StandardRateValidation(standardRateMain, true);
                standardRateMain.UserDomainKey = standardRateMainRepository.UserDomainKey;
                standardRateMain.IsActive = true;
                standardRateMain.IsDeleted = false;
                standardRateMain.IsPrivate = false;
                standardRateMain.IsReadOnly = false;
                standardRateMain.RecCreatedDt = DateTime.Now;
                standardRateMain.RecLastUpdatedDt = DateTime.Now;
                standardRateMain.RecCreatedBy = standardRateMainRepository.LoggedInUserIdentity;
                standardRateMain.RecLastUpdatedBy = standardRateMainRepository.LoggedInUserIdentity;
                standardRateMain.RowVersion = 0;
                //set child (Standard Rate in Standard Rate Main) properties
                #region Standard Rate in Standard Rate Main

                if (standardRateMain.StandardRates != null)
                {
                    // set properties
                    foreach (StandardRate item in standardRateMain.StandardRates)
                    {
                        item.IsActive = true;
                        item.IsDeleted = false;
                        item.IsPrivate = false;
                        item.IsReadOnly = false;
                        item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedDt = DateTime.Now;
                        item.RecCreatedBy = standardRateMainRepository.LoggedInUserIdentity;
                        item.RecLastUpdatedBy = standardRateMainRepository.LoggedInUserIdentity;
                        item.UserDomainKey = standardRateMainRepository.UserDomainKey;
                    }
                }

                #endregion
                standardRateMainRepository.Add(standardRateMain);
                standardRateMainRepository.SaveChanges();
            }
            #endregion

            #region Edit
            else
            {
                StandardRateValidation(standardRateMain, false);
                if (standardRateMain.StandardRates != null)
                {
                    foreach (StandardRate standardRate in standardRateMain.StandardRates)
                    {
                        standardRate.IsActive = true;
                        standardRate.IsDeleted = false;
                        standardRate.IsPrivate = false;
                        standardRate.IsReadOnly = false;
                        standardRate.RecCreatedDt = DateTime.Now;
                        standardRate.RecLastUpdatedDt = DateTime.Now;
                        standardRate.RecCreatedBy = standardRateMainRepository.LoggedInUserIdentity;
                        standardRate.RecLastUpdatedBy = standardRateMainRepository.LoggedInUserIdentity;
                        standardRate.UserDomainKey = standardRateMainRepository.UserDomainKey;
                        standardRate.StandardRtMainId = standardRateMain.StandardRtMainId;
                        if (standardRate.StandardRtId > 0)
                        {
                            long oldRecordId = standardRate.StandardRtId;
                            standardRate.StandardRtId = 0;
                            standardRate.RevisionNumber = standardRate.RevisionNumber + 1;
                            standardRateRepository.Add(standardRate);
                            standardRateRepository.SaveChanges();
                            StandardRate oldStandardRate = standardRateRepository.Find(oldRecordId);
                            oldStandardRate.ChildStandardRtId = standardRate.StandardRtId;
                            standardRateRepository.SaveChanges();
                        }
                        else
                        {
                            standardRateRepository.Add(standardRate);
                            standardRateRepository.SaveChanges();
                        }
                    }
                }

            }
            #endregion

            return new TariffRateContent
           {
               StandardRtMainId = standardRateMain.StandardRtMainId,
               StandardRtMainCode = standardRateMain.StandardRtMainCode,
               StandardRtMainName = standardRateMain.StandardRtMainName,
               StandardRtMainDescription = standardRateMain.StandardRtMainDescription,
               StartDt = standardRateMain.StartDt,
               EndDt = standardRateMain.EndDt,
               TariffTypeId = tariffType.TariffTypeId,
               TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
               OperationId = tariffType.OperationId,
               OperationCodeName =
                   tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
           };
        }

        /// <summary>
        /// Delete Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        public void DeleteTariffRate(StandardRateMain standardRateMain)
        {
            if (standardRateMain.StandardRates != null && standardRateMain.StandardRates.Count > 0)
            {
                throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.StRateIsAssociatedWithHireGroupError));
            }
            standardRateMainRepository.Delete(standardRateMain);
            standardRateMainRepository.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        public IEnumerable<StandardRate> FindStandardRate(long standardRtMainId, long hireGroupDetailId)
        {
            return standardRateRepository.FindByHireGroupId(standardRtMainId, hireGroupDetailId);
        }

        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        public IEnumerable<StandardRateMain> FindByTariffTypeCode(string tariffTypeCode)
        {
            return standardRateMainRepository.FindByTariffTypeCode(tariffTypeCode);
        }

        /// <summary>
        /// Find Tariff Type By Tariff Type ID
        /// </summary>
        /// <param name="tariffTypeId"> Tariff Type Id</param>
        /// <returns></returns>
        public TariffType FindTariffTypeById(long tariffTypeId)
        {
            return tariffTypeRepository.Find(tariffTypeId);
        }

        /// <summary>
        /// Standard Rate Validation
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <param name="addFlag"></param>
        private void StandardRateValidation(StandardRateMain standardRateMain, bool addFlag)
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            DateTime strMainStartDate, strMainEndDate, dbStartDate, dbEndDate;
            strMainStartDate = Convert.ToDateTime(standardRateMain.StartDt);
            strMainEndDate = Convert.ToDateTime(standardRateMain.EndDt);
            if (addFlag)
            {
                if (strMainStartDate.Date < DateTime.Now.Date)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.InvalidStartDate));
                if (strMainEndDate.Date < strMainStartDate.Date)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.InvalidEndDate));
                IEnumerable<StandardRateMain> oStRateMain = FindByTariffTypeCode(standardRateMain.TariffTypeCode).Select(s => s);
                foreach (var rateMain in oStRateMain)
                {
                    dbStartDate = rateMain.StartDt;
                    dbEndDate = rateMain.EndDt;

                    if ((strMainStartDate <= dbStartDate) && ((dbEndDate) <= (strMainEndDate)))
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.ExistingStandardRtOverlaps));
                    if ((dbStartDate <= strMainStartDate) && ((strMainEndDate) <= (dbEndDate)))
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.CurrentStandardRtOverlaps));
                    if ((dbStartDate <= strMainStartDate) && (strMainStartDate <= (dbEndDate)) && ((dbEndDate) <= (strMainEndDate)))
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.StartStandardRtDurationOverlaps));
                    if ((strMainStartDate <= dbStartDate) && (dbStartDate <= (strMainEndDate)) && ((strMainEndDate) <= (dbEndDate)))
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.EndStandardRtDurationOverlaps));
                }
            }
            if (standardRateMain.StandardRates != null)
            {
                foreach (var standardRate in standardRateMain.StandardRates)
                {
                    dbStartDate = Convert.ToDateTime(standardRate.StandardRtStartDt);
                    dbEndDate = Convert.ToDateTime(standardRate.StandardRtEndDt);
                    if (dbStartDate.Date < DateTime.Now.Date || dbEndDate.Date < DateTime.Now.Date)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.StRateInvalidEffectiveDates));
                    if (dbEndDate < dbStartDate)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.StRateInvalidEndDate));
                    if (dbStartDate < strMainStartDate || dbEndDate > strMainEndDate)
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.TariffRate.StRateInvalidRangeEffectiveDate));
                }
            }

        }

        #endregion
    }
}


