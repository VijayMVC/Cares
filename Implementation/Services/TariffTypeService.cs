using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// tariff TypeS ervice
    /// </summary>
    public class TariffTypeService : ITariffTypeService
    {
        #region Private
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMeasurementUnit measurementUnit;
        private readonly IOperationRepository operationRepository;
        private readonly IPricingStrategyRepository pricingStrategyRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;

        #endregion
       
        #region Constructors
        public TariffTypeService(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IMeasurementUnit measurementUnit,
           IOperationRepository operationRepository, IPricingStrategyRepository pricingStrategyRepository, ITariffTypeRepository tariffTypeRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.measurementUnit = measurementUnit;
            this.pricingStrategyRepository = pricingStrategyRepository;
            this.tariffTypeRepository = tariffTypeRepository;

        }
        #endregion
        
        #region Public

        public TariffTypeBaseResponse GetBaseData()
        {
            return new TariffTypeBaseResponse
            {
                Companies = companyRepository.GetAll(),
                MeasurementUnits = measurementUnit.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetSalesOperation(),
                PricingStrategies = pricingStrategyRepository.GetAll()

            };

        }
        public IEnumerable<TariffType> LoadAll()
        {
            return tariffTypeRepository.GetAll();
        }
        /// <summary>
        /// Load tariff type, based on search filters
        /// </summary>
        /// <param name="tariffTypeRequest"></param>
        /// <returns></returns>
        public TariffTypeResponse LoadtariffTypes(TariffTypeRequest tariffTypeRequest)
        {
            return tariffTypeRepository.GettariffTypes(tariffTypeRequest);
        }
        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TariffTypeDetailResponse FindDetailById(long id)
        {
            List<TariffType> revisionList = new List<TariffType>();
            var tariffType = tariffTypeRepository.Find(id);

            if (tariffType != null && tariffType.RevisionNumber > 0)
            {
                var tempId = tariffType.TariffTypeId;
                for (int i = 0; i < tariffType.RevisionNumber; i++)
                {
                    if (tempId > 0)
                    {
                        var tariffRevision = tariffTypeRepository.GetRevison(tempId);
                        tempId = tariffRevision != null ? tariffRevision.TariffTypeId : 0;
                        revisionList.Add(tariffRevision);
                    }
                }
            }
            return new TariffTypeDetailResponse { TariffType = tariffType, TariffTypeRevisions = revisionList };
        }
        /// <summary>
        /// Add Tariff Type
        /// </summary>
        /// <param name="tariffType"></param>
        /// <returns></returns>
        public TariffType AddtariffType(TariffType tariffType)
        {
            long oldRecordId = tariffType.TariffTypeId;
            if (tariffType.TariffTypeId == 0) //Add Case
            {
                tariffType.IsActive = true;
                tariffType.IsDeleted = tariffType.IsPrivate = tariffType.IsReadOnly = false;
                tariffType.RecLastUpdatedBy = tariffType.RecCreatedBy = tariffTypeRepository.LoggedInUserIdentity;
                tariffType.RecCreatedDt = tariffType.RecLastUpdatedDt = DateTime.Now;
                tariffType.RowVersion = 0;
                tariffType.UserDomainKey = tariffTypeRepository.UserDomainKey;
                tariffTypeRepository.Add(tariffType);
                tariffTypeRepository.SaveChanges();
            }
            else //Update Case
            {
                tariffType.IsActive = true;
                tariffType.IsDeleted = tariffType.IsPrivate = tariffType.IsReadOnly = false;
                tariffType.RecLastUpdatedBy = tariffType.RecCreatedBy = tariffTypeRepository.LoggedInUserIdentity;
                tariffType.RecCreatedDt = tariffType.RecLastUpdatedDt = DateTime.Now;
                tariffType.RevisionNumber = tariffType.RevisionNumber + 1;
                tariffType.UserDomainKey = tariffTypeRepository.UserDomainKey;
                tariffTypeRepository.Add(tariffType);
                tariffTypeRepository.SaveChanges();

                TariffType oldTariffRecord = tariffTypeRepository.Find(oldRecordId);
                oldTariffRecord.ChildTariffTypeId = tariffType.TariffTypeId;
                tariffTypeRepository.SaveChanges();
            }
            TariffType tariff = tariffTypeRepository.Find(tariffType.TariffTypeId);
            tariffTypeRepository.LoadDependencies(tariff);
            return tariff;

        }

        #endregion
    }
}
