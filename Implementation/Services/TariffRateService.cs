using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
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
        private readonly ITarrifTypeRepository tarrifTypeRepository;
        private readonly IStandardRateMainRepository standardRateMainRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IStandardRateRepository standardRateRepository;

        #endregion
        #region Constructors
        public TariffRateService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IOperationRepository operationRepository,
            IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IHireGroupRepository hireGroupRepository, ITarrifTypeRepository tarrifTypeRepository, IStandardRateMainRepository standardRateMainRepository,
            IHireGroupDetailRepository hireGroupDetailRepository, IStandardRateRepository standardRateRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.hireGroupRepository = hireGroupRepository;
            this.tarrifTypeRepository = tarrifTypeRepository;
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
                TariffTypes = tarrifTypeRepository.GetAll(),
            };
        }
        /// <summary>
        /// Get Stanadrd Rate Main
        /// </summary>
        /// <param name="tariffRateRequest"></param>
        /// <returns></returns>
        public TariffRateResponse LoadTariffRates(TariffRateRequest tariffRateRequest)
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
            IEnumerable<StandardRate> standardRates = standardRateRepository.GetStandardRateForTariffRate(standardRtMainId);
            return new HireGroupDetailResponse { HireGroupDetails = hireGroupDetails, StandardRates = standardRates, StandardRateId = standardRtMainId };
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
        public TariffRateContent AddTariffRate(StandardRateMain standardRateMain)
        {
            standardRateMain.RecCreatedDt = System.DateTime.Now;
            standardRateMain.RecLastUpdatedDt = System.DateTime.Now;
            standardRateMain.UserDomainKey = standardRateMainRepository.UserDomainKey;
            TarrifType tarrifType = tarrifTypeRepository.Find(long.Parse(standardRateMain.TariffTypeCode));
            standardRateMain.TariffTypeCode = tarrifType.TariffTypeCode;
            standardRateMainRepository.Add(standardRateMain);
            standardRateMainRepository.SaveChanges();
            return new TariffRateContent
                   {
                       StandardRtMainId = standardRateMain.StandardRtMainId,
                       StandardRtMainCode = standardRateMain.StandardRtMainCode,
                       StandardRtMainName = standardRateMain.StandardRtMainName,
                       StandardRtMainDescription = standardRateMain.StandardRtMainDescription,
                       StartDt = standardRateMain.StartDt,
                       EndDt = standardRateMain.EndDt,
                       TariffTypeId = tarrifType.TariffTypeId,
                       TariffTypeCodeName = tarrifType.TariffTypeCode + " - " + tarrifType.TariffTypeName,
                       OperationId = tarrifType.OperationId,
                       OperationCodeName = tarrifType.Operation.OperationCode + " - " + tarrifType.Operation.OperationName,
                   };
        }

        /// <summary>
        /// Add Standard Rate
        /// </summary>
        /// <param name="standardRate"></param>
        /// <returns></returns>
        public void AddStandardRate(StandardRate standardRate)
        {
            standardRate.RecCreatedDt = System.DateTime.Now;
            standardRate.RecLastUpdatedDt = System.DateTime.Now;
            standardRate.UserDomainKey = standardRateMainRepository.UserDomainKey;
            if (standardRate.StandardRtId > 0)
            {
                long oldRecordId = standardRate.StandardRtId;
                standardRate.StandardRtId = 0;
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

            //standardRateRepository.FindByHireGroupId(standardRate.StandardRtMainId, standardRate.HireGroupDetailId);
        }
        /// <summary>
        /// Update Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <returns></returns>
        public TariffRateContent Update(StandardRateMain standardRateMain)
        {
            standardRateMain.RecCreatedDt = System.DateTime.Now;
            standardRateMain.RecLastUpdatedDt = System.DateTime.Now;
            TarrifType tarrifType = tarrifTypeRepository.Find(long.Parse(standardRateMain.TariffTypeCode));
            standardRateMain.TariffTypeCode = tarrifType.TariffTypeCode;
            standardRateMainRepository.Update(standardRateMain);
            standardRateMainRepository.SaveChanges(); 
            return new TariffRateContent
            {
                StandardRtMainId = standardRateMain.StandardRtMainId,
                StandardRtMainCode = standardRateMain.StandardRtMainCode,
                StandardRtMainName = standardRateMain.StandardRtMainName,
                StandardRtMainDescription = standardRateMain.StandardRtMainDescription,
                StartDt = standardRateMain.StartDt,
                EndDt = standardRateMain.EndDt,
                TariffTypeId = tarrifType.TariffTypeId,
                TariffTypeCodeName = tarrifType.TariffTypeCode + " - " + tarrifType.TariffTypeName,
                OperationId = tarrifType.OperationId,
                OperationCodeName = tarrifType.Operation.OperationCode + " - " + tarrifType.Operation.OperationName,
            };
        }
        /// <summary>
        /// Delete Tariff Rate
        /// </summary>
        /// <param name="standardRateMain"></param>
        public void DeleteTariffRate(StandardRateMain standardRateMain)
        {
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
        #endregion
    }
}
