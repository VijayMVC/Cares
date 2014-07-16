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
        private readonly ITarrifTypeRepository tarrifTypeReposiory;
        private readonly IDepartmentService departmentService;
        private readonly ICompanyService companyService;
        private readonly IMeasurementUnitService measurementUnitService;
        private readonly IOperationService operation;
        private readonly ITarrifTypeService tarrifTypeService;
        private readonly IPricingStrategyService pricingStrategyService;
        #endregion
        #region Constructors
        public TarrifTypeService(ITarrifTypeRepository tarrifTypeReposiory, IOperationService operation, IDepartmentService departmentService, ICompanyService companyService,
           IMeasurementUnitService measurementUnitService, ITarrifTypeService tarrifTypeService, IPricingStrategyService pricingStrategyService)
        {
            this.operation = operation;
            this.departmentService = departmentService;
            this.companyService = companyService;
            this.measurementUnitService = measurementUnitService;
            this.tarrifTypeService = tarrifTypeService;
            this.pricingStrategyService = pricingStrategyService;
            this.tarrifTypeReposiory = tarrifTypeReposiory;
        }
        #endregion
        #region Public

        public TarrifTypeBaseResponse GetBaseData()
        {
            //TODO: 
            return null;
        }

        public IEnumerable<TarrifType> LoadAll()
        {
            return tarrifTypeReposiory.GetAll();
        }
        /// <summary>
        /// Load tarrif type, based on search filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        public TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            return tarrifTypeReposiory.GetTarrifTypes(tarrifTypeRequest);
        }
        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TarrifType FindTarrifType(long id)
        {
            return tarrifTypeReposiory.Find(id);
        }
        /// <summary>
        /// Add Tariff Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        public bool AddTarrifType(TarrifType tarrifType)
        {
            tarrifTypeReposiory.Add(tarrifType);
            tarrifTypeReposiory.SaveChanges();
            return true;
        }
        /// <summary>
        /// Update Tariff Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        public bool UpdateTarrifType(TarrifType tarrifType)
        {
            tarrifTypeReposiory.Update(tarrifType);
            tarrifTypeReposiory.SaveChanges();
            return true;

        }


        #endregion

    }
}
