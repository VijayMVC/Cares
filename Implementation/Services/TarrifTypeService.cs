using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Tarrif TypeS ervice
    /// </summary>
    public class TarrifTypeService : ITarrifTypeService
    {
        #region Private
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMeasurementUnit measurementUnit;
        private readonly IOperationRepository operationRepository;
        private readonly IPricingStrategyRepository pricingStrategyRepository;
        private readonly ITarrifTypeRepository tarrifTypeRepository;

        #endregion
        #region Constructors
        public TarrifTypeService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IMeasurementUnit measurementUnit,
           IOperationRepository operationRepository, IPricingStrategyRepository pricingStrategyRepository, ITarrifTypeRepository tarrifTypeRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.measurementUnit = measurementUnit;
            this.pricingStrategyRepository = pricingStrategyRepository;
            this.tarrifTypeRepository = tarrifTypeRepository;

        }
        #endregion
        #region Public

        public TarrifTypeBaseResponse GetBaseData()
        {
            return new TarrifTypeBaseResponse
            {
                Companies = companyRepository.GetAll(),
                MeasurementUnits = measurementUnit.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                PricingStrategies = pricingStrategyRepository.GetAll()

            };

        }
        public IEnumerable<TarrifType> LoadAll()
        {
            return tarrifTypeRepository.GetAll();
        }
        /// <summary>
        /// Load tarrif type, based on search filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        public TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            return tarrifTypeRepository.GetTarrifTypes(tarrifTypeRequest);
        }
        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TariffTypeDetailResponse FindDetailById(long id)
        {
            List<TarrifType> revisionList = new List<TarrifType>();
            var tarrifType = tarrifTypeRepository.Find(id);
            if (tarrifType != null && tarrifType.RevisionNumber > 0)
            {
                var tempId = tarrifType.TariffTypeId;
                for (int i = 0; i < tarrifType.RevisionNumber; i++)
                {
                    if (tempId > 0)
                    {
                        var tariffRevision = tarrifTypeRepository.GetRevison(tempId);
                        tempId = tariffRevision != null ? tariffRevision.TariffTypeId : 0;
                        revisionList.Add(tariffRevision);
                    }
                }
            }
            return new TariffTypeDetailResponse { TarrifType = tarrifType, TarrifTypeRevisions = revisionList };
        }
        /// <summary>
        /// Add Tariff Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        public TarrifType AddTarrifType(TarrifType tarrifType)
        {
            tarrifTypeRepository.Add(tarrifType);
            tarrifTypeRepository.SaveChanges();
            TarrifType tarrif = tarrifTypeRepository.Find(tarrifType.TariffTypeId);
            tarrifTypeRepository.LoadDependencies(tarrif);
            return tarrif;
        }
        /// <summary>
        /// Update Tariff Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        public TarrifType UpdateTarrifType(TarrifType tarrifType)
        {
            long oldRecordId = tarrifType.TariffTypeId;
            tarrifType.TariffTypeId = 0;
            tarrifType.RevisionNumber = tarrifType.RevisionNumber + 1;
            tarrifTypeRepository.Add(tarrifType);
            tarrifTypeRepository.SaveChanges();
            TarrifType oldTariffRecord = tarrifTypeRepository.Find(oldRecordId);
            oldTariffRecord.ChildTariffTypeId = tarrifType.TariffTypeId;
            tarrifTypeRepository.SaveChanges();
            tarrifTypeRepository.LoadDependencies(tarrifType);
            return tarrifType;
        }
        #endregion
    }
}
