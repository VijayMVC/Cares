using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Additional Driver Service
    /// </summary>
    public class AdditionalDriverService : IAdditionalDriverService
    {
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IAdditionalDriverChargeRepository additionalDriverChargeRepository;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        public AdditionalDriverService(ICompanyRepository companyRepository, IAdditionalDriverChargeRepository additionalDriverChargeRepository,
            IDepartmentRepository departmentRepository, IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository)
        {
            this.companyRepository = companyRepository;
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.departmentRepository = departmentRepository;
            this.additionalDriverChargeRepository = additionalDriverChargeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load company Base data
        /// </summary>
        public AdditionalDriverBaseResponse GetBaseData()
        {
            return new AdditionalDriverBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                TariffTypes = tariffTypeRepository.GetAll(),

            };
        }

        /// <summary>
        /// Get Additional Driver Charge Detail
        /// </summary>
        /// <param name="additionalDriverChargeId"></param>
        /// <returns></returns>
        public IEnumerable<AdditionalDriverCharge> GetAdditionalDriverChargeDetail(long additionalDriverChargeId)
        {
            List<AdditionalDriverCharge> revisionList = new List<AdditionalDriverCharge>();
            var addDriverChrg = additionalDriverChargeRepository.Find(additionalDriverChargeId);

            if (addDriverChrg != null && addDriverChrg.RevisionNumber > 0)
            {
                var tempId = addDriverChrg.AdditionalDriverChargeId;
                for (int i = 0; i < addDriverChrg.RevisionNumber; i++)
                {
                    if (tempId > 0)
                    {
                        var revision = additionalDriverChargeRepository.GetRevision(tempId);
                        tempId = revision != null ? revision.AdditionalDriverChargeId : 0;
                        revisionList.Add(revision);
                    }
                }
            }
            return revisionList;

        }

        /// <summary>
        /// Load Additional Driver Charge Based on search criteria
        /// </summary>
        /// <returns></returns>
        public AdditionalDriverChargeSearchResponse LoadAll(AdditionalDriverChargeSearchRequest request)
        {
            return additionalDriverChargeRepository.GetAdditionalDriverCharges(request);
        }

        /// <summary>
        /// Add Additional Driver Charge
        /// </summary>
        /// <param name="additionalDriverCharge"></param>
        /// <returns></returns>
        public AdditionalDriverChargeSearchContent SaveAdditionalDriverCharge(AdditionalDriverCharge additionalDriverCharge)
        {
            TariffType tariffType = tariffTypeRepository.Find(long.Parse(additionalDriverCharge.TariffTypeCode));
            additionalDriverCharge.TariffTypeCode = tariffType.TariffTypeCode;
            long oldRecordId = additionalDriverCharge.AdditionalDriverChargeId;
            if (additionalDriverCharge.AdditionalDriverChargeId == 0) //Add Case
            {
                additionalDriverCharge.IsActive = true;
                additionalDriverCharge.IsDeleted = additionalDriverCharge.IsPrivate = additionalDriverCharge.IsReadOnly = false;
                additionalDriverCharge.RecLastUpdatedBy = additionalDriverCharge.RecCreatedBy = additionalDriverChargeRepository.LoggedInUserIdentity;
                additionalDriverCharge.RecCreatedDt = additionalDriverCharge.RecLastUpdatedDt = DateTime.Now;
                additionalDriverCharge.RowVersion = 0;
                additionalDriverCharge.UserDomainKey = additionalDriverChargeRepository.UserDomainKey;
                additionalDriverChargeRepository.Add(additionalDriverCharge);
                additionalDriverChargeRepository.SaveChanges();
            }
            else //Update Case
            {
                additionalDriverCharge.IsActive = true;
                additionalDriverCharge.IsDeleted = additionalDriverCharge.IsPrivate = additionalDriverCharge.IsReadOnly = false;
                additionalDriverCharge.RecLastUpdatedBy = additionalDriverCharge.RecCreatedBy = additionalDriverChargeRepository.LoggedInUserIdentity;
                additionalDriverCharge.RecCreatedDt = additionalDriverCharge.RecLastUpdatedDt = DateTime.Now;
                additionalDriverCharge.RevisionNumber = additionalDriverCharge.RevisionNumber + 1;
                additionalDriverCharge.UserDomainKey = additionalDriverChargeRepository.UserDomainKey;
                additionalDriverCharge.AdditionalDriverChargeId = 0;
                additionalDriverChargeRepository.Add(additionalDriverCharge);
                additionalDriverChargeRepository.SaveChanges();

                AdditionalDriverCharge oldAdditionalDriverChargeRecord = additionalDriverChargeRepository.Find(oldRecordId);
                oldAdditionalDriverChargeRecord.ChildAdditionalDriverChargeId = additionalDriverCharge.AdditionalDriverChargeId;
                additionalDriverChargeRepository.SaveChanges();
            }
            return new AdditionalDriverChargeSearchContent
          {
              AdditionalDriverChargeId = additionalDriverCharge.AdditionalDriverChargeId,
              TariffTypeCode = tariffType.TariffTypeCode,
              TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
              AdditionalDriverChargeRate = additionalDriverCharge.AdditionalDriverChargeRate,
              StartDt = additionalDriverCharge.StartDt,
              CompanyCodeName = tariffType.Operation.Department.Company.CompanyCode + " - " + tariffType.Operation.Department.Company.CompanyName,
              OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
              RevisionNumber = additionalDriverCharge.RevisionNumber,
              CompanyId = tariffType.Operation.Department.Company.CompanyId,
              DepartmentId = tariffType.Operation.Department.DepartmentId,
              OperationId = tariffType.Operation.OperationId,
              TariffTypeId = tariffType.TariffTypeId,
          };

        }

        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="additionalDriverChargeId"></param>
        /// <returns></returns>
        public AdditionalDriverCharge FindById(long additionalDriverChargeId)
        {
            return additionalDriverChargeRepository.Find(additionalDriverChargeId);
        }


        /// <summary>
        /// Additional Driver Charge Delete
        /// </summary>
        /// <param name="additionalDriverCharge"></param>
        public void AdditionalDriverChargeDelete(AdditionalDriverCharge additionalDriverCharge)
        {
            additionalDriverChargeRepository.Delete(additionalDriverCharge);
            additionalDriverChargeRepository.SaveChanges();
        }
        #endregion
    }
}
