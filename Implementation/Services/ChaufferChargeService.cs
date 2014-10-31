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
    /// Chauffer Charge Service
    /// </summary>
    public class ChaufferChargeService : IChaufferChargeService
    {
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IChaufferChargeRepository chaufferChargeRepository;
        private readonly IChaufferChargeMainRepository chaufferChargeMainRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IDesignGradeRepository designGradeRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public ChaufferChargeService(IChaufferChargeRepository chaufferChargeRepository,
            IChaufferChargeMainRepository chaufferChargeMainRepository, ICompanyRepository companyRepository,
            IDepartmentRepository departmentRepository, IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
            IDesignGradeRepository designGradeRepository)
        {
            this.chaufferChargeRepository = chaufferChargeRepository;
            this.chaufferChargeMainRepository = chaufferChargeMainRepository;
            this.companyRepository = companyRepository;
            this.departmentRepository = departmentRepository;
            this.operationRepository = operationRepository;
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.designGradeRepository = designGradeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Chauffer Charge Base data
        /// </summary>
        public ChaufferChargeBaseResponse GetBaseData()
        {
            return new ChaufferChargeBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                TariffTypes = tariffTypeRepository.GetAll(),
                DesigGrades = designGradeRepository.GetAll(),
            };
        }

        /// <summary>
        /// Load Chauffer Charge Main  Based on search criteria
        /// </summary>
        /// <returns></returns>
        public ChaufferChargeSearchResponse LoadAll(ChaufferChargeSearchRequest request)
        {
            return chaufferChargeMainRepository.GetChaufferCharges(request);
        }

        /// <summary>
        /// Save Chauffer Charge Main
        /// </summary>
        /// <param name="chaufferChargeMain"></param>
        /// <returns></returns>
        public ChaufferChargeMainContent SaveChaufferCharge(ChaufferChargeMain chaufferChargeMain)
        {
            //Code Duplication Check
            if (chaufferChargeMainRepository.IsChauffeurChargeMainCodeExists(chaufferChargeMain.ChaufferChargeMainCode,
              chaufferChargeMain.ChaufferChargeMainId))
            {
                throw new CaresException(Resources.Tariff.ChaufferCharge.CodeDuplicationError);
            }

            ChaufferChargeMain chaufferChargeMainDbVersion =
               chaufferChargeMainRepository.Find(chaufferChargeMain.ChaufferChargeMainId);
            TariffType tariffType = tariffTypeRepository.Find(long.Parse(chaufferChargeMain.TariffTypeCode));
            chaufferChargeMain.TariffTypeCode = tariffType.TariffTypeCode;
            if (chaufferChargeMainDbVersion == null) //Add Case
            {
                //Validate Chauffer Charge Main
                ChaufferChargeValidation(chaufferChargeMain, true);
                chaufferChargeMain.IsActive = true;
                chaufferChargeMain.IsDeleted =
                    chaufferChargeMain.IsPrivate = chaufferChargeMain.IsReadOnly = false;
                chaufferChargeMain.RecLastUpdatedBy =
                    chaufferChargeMain.RecCreatedBy = chaufferChargeMainRepository.LoggedInUserIdentity;
                chaufferChargeMain.RecCreatedDt = chaufferChargeMain.RecLastUpdatedDt = DateTime.Now;
                chaufferChargeMain.RowVersion = 0;
                chaufferChargeMain.UserDomainKey = chaufferChargeMainRepository.UserDomainKey;

                if (chaufferChargeMain.ChaufferCharges != null)
                {
                    foreach (var item in chaufferChargeMain.ChaufferCharges)
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy = item.RecCreatedBy = chaufferChargeMainRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.RevisionNumber = 0;
                        item.UserDomainKey = chaufferChargeMainRepository.UserDomainKey;
                    }
                }
                chaufferChargeMainRepository.Add(chaufferChargeMain);
            }
            else //Update
            {
                chaufferChargeMainDbVersion.RecLastUpdatedBy = chaufferChargeMainRepository.LoggedInUserIdentity;
                chaufferChargeMainDbVersion.RecLastUpdatedDt = DateTime.Now;
                chaufferChargeMainDbVersion.StartDt = chaufferChargeMain.StartDt;
                if (chaufferChargeMain.ChaufferCharges != null)
                {
                    //Validate Chauffer Charge Main
                    ChaufferChargeValidation(chaufferChargeMain, false);

                    foreach (var item in chaufferChargeMain.ChaufferCharges)
                    {
                        if (
                            chaufferChargeMainDbVersion.ChaufferCharges.All(
                                x =>
                                    x.ChaufferChargeId != item.ChaufferChargeId ||
                                    item.ChaufferChargeId == 0))
                        {
                            item.IsActive = true;
                            item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                            item.RecLastUpdatedBy =
                                item.RecCreatedBy = chaufferChargeMainRepository.LoggedInUserIdentity;
                            item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                            item.RowVersion = 0;
                            item.RevisionNumber = 0;
                            item.UserDomainKey = chaufferChargeMainRepository.UserDomainKey;
                            chaufferChargeMainDbVersion.ChaufferCharges.Add(item);
                        }
                        else
                        {
                            if (chaufferChargeMainDbVersion.ChaufferCharges.Any(
                                x =>
                                    x.ChaufferChargeId == item.ChaufferChargeId))
                            {
                                ChaufferCharge chaufferChargeDbVesion =
                                    chaufferChargeMainDbVersion.ChaufferCharges.First(
                                        x => x.ChaufferChargeId == item.ChaufferChargeId);
                                if (chaufferChargeDbVesion.DesigGradeId != item.DesigGradeId ||
                                    chaufferChargeDbVesion.StartDt != item.StartDt
                                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                                    || chaufferChargeDbVesion.ChaufferChargeRate != item.ChaufferChargeRate)
                                {
                                    item.IsActive = true;
                                    item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                                    item.RecLastUpdatedBy =
                                        item.RecCreatedBy = chaufferChargeMainRepository.LoggedInUserIdentity;
                                    item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                                    item.RowVersion = 0;
                                    item.ChaufferChargeMainId = chaufferChargeMain.ChaufferChargeMainId;
                                    item.RevisionNumber = chaufferChargeDbVesion.RevisionNumber + 1;
                                    item.ChaufferChargeId = 0;
                                    item.UserDomainKey = chaufferChargeMainRepository.UserDomainKey;
                                    chaufferChargeRepository.Add(item);
                                    chaufferChargeRepository.SaveChanges();
                                    chaufferChargeDbVesion.ChildChaufferChargeId = item.ChaufferChargeMainId;
                                }
                            }
                        }
                    }
                }
            }
            chaufferChargeMainRepository.SaveChanges();
            return new ChaufferChargeMainContent
                                     {
                                         ChaufferChargeMainId = chaufferChargeMain.ChaufferChargeMainId,
                                         Code = chaufferChargeMain.ChaufferChargeMainCode,
                                         Name = chaufferChargeMain.ChaufferChargeMainName,
                                         Description = chaufferChargeMain.ChaufferChargeMainDescription,
                                         StartDate = chaufferChargeMain.StartDt,
                                         TariffTypeId = tariffType.TariffTypeId,
                                         CompanyId = tariffType.Operation.Department.Company.CompanyId,
                                         CompanyCodeName = tariffType.Operation.Department.Company.CompanyCode + " - " + tariffType.Operation.Department.Company.CompanyName,
                                         DepartmentId = tariffType.Operation.Department.DepartmentId,
                                         TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                         OperationId = tariffType.OperationId,
                                         OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                     };

        }

        /// <summary>
        /// Delete Chauffer Charge
        /// </summary>
        /// <param name="chaufferChargeMain"></param>
        public void DeleteAdditionalCharge(ChaufferChargeMain chaufferChargeMain)
        {
            chaufferChargeMainRepository.Delete(chaufferChargeMain);
            chaufferChargeMainRepository.SaveChanges();
        }

        /// <summary>
        /// Find Chauffer Charge By Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        public ChaufferChargeMain FindById(long chaufferChargeMainId)
        {
            return chaufferChargeMainRepository.Find(chaufferChargeMainId);
        }

        /// <summary>
        /// Get Chauffer Charges By Chauffer Charge Main Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        public IEnumerable<ChaufferCharge> GetChaufferChargesByChaufferChargeMainId(long chaufferChargeMainId)
        {
            return chaufferChargeRepository.GetChaufferChargesByChaufferChargeMainId(chaufferChargeMainId);
        }

        /// <summary>
        /// hauffer Charge Validation
        /// </summary>
        /// <param name="chaufferChargeMain"></param>
        /// <param name="flag"></param>
        private void ChaufferChargeValidation(ChaufferChargeMain chaufferChargeMain, bool flag)
        {
            // ReSharper disable once TooWideLocalVariableScope
            DateTime chaufferChargeMainStDate, chaufferChargeStDate;
            chaufferChargeMainStDate = Convert.ToDateTime(chaufferChargeMain.StartDt);
            if (flag)
            {
                if (chaufferChargeMainStDate < DateTime.Now.Date)
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ChaufferCharge.InvalidStartDate));
                if (chaufferChargeMainRepository.LoadChaufferChargeMainExist(chaufferChargeMain.TariffTypeCode))
                {
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ChaufferCharge.ChaufferChargeByTariffExist));
                }
            }
            if (chaufferChargeMain.ChaufferCharges != null)
            {

                foreach (var item in chaufferChargeMain.ChaufferCharges)
                {
                    chaufferChargeStDate = Convert.ToDateTime(item.StartDt);

                    if (item.ChaufferChargeId == 0)
                    {
                        if (chaufferChargeStDate < DateTime.Now.Date)
                            throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ChaufferCharge.ChaufferChargeInvalidEffectiveDates));

                        if (chaufferChargeStDate < chaufferChargeMainStDate)
                            throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Tariff.ChaufferCharge.ChaufferChargeInvalidRangeEffectiveDate));
                    }
                }
            }
        }

        #endregion
    }
}
