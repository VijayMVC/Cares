using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
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
        public TarrifType FindTarrifType(long id)
        {
            return tarrifTypeRepository.Find(id);
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
            var tarrif = tarrifTypeRepository.Find(tarrifType.TariffTypeId);
            // TODO: Sample Loading Dependencies
            tarrifTypeRepository.LoadDependencies(tarrif);
            return tarrif;
        }
        /// <summary>
        /// Update Tariff Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        public bool UpdateTarrifType(TarrifType tarrifType)
        {
            tarrifTypeRepository.Update(tarrifType);
            tarrifTypeRepository.SaveChanges();
            return true;

        }


        #endregion

    }
}
