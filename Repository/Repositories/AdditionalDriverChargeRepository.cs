using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Additional Driver Charge Repository
    /// </summary>
    public class AdditionalDriverChargeRepository : BaseRepository<AdditionalDriverCharge>, IAdditionalDriverChargeRepository
    {
        #region Private
        private readonly Dictionary<AdditionalDriverChargeByColumn, Func<AdditionalDriverChargeSearchContent, object>> additionalDriverChargeClause =
             new Dictionary<AdditionalDriverChargeByColumn, Func<AdditionalDriverChargeSearchContent, object>>
                    {
                        { AdditionalDriverChargeByColumn.TariffTypeCode, c => c.TariffTypeCode },
                        { AdditionalDriverChargeByColumn.TariffTypeName, c => c.TariffTypeCodeName }
                    };

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AdditionalDriverCharge> DbSet
        {
            get
            {
                return db.AdditionalDriverCharges;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Additional Driver Charge for User Domain Key
        /// </summary>
        public override IEnumerable<AdditionalDriverCharge> GetAll()
        {
            return DbSet.Where(addDriverChrg => addDriverChrg.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Additional Driver Charges based on search crateria
        /// </summary>
        public AdditionalDriverChargeSearchResponse GetAdditionalDriverCharges(AdditionalDriverChargeSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            var getInsuranceRateQuery = from addDriverChrg in DbSet
                                        join tariffType in db.TariffTypes on addDriverChrg.TariffTypeCode equals tariffType.TariffTypeCode
                                        where
                                            (!addDriverChrg.ChildAdditionalDriverChargeId.HasValue &&
                                            (!request.OperationId.HasValue ||
                                              tariffType.OperationId == request.OperationId.Value) &&
                                             (!request.TariffTypeId.HasValue ||
                                              tariffType.TariffTypeId == request.TariffTypeId))
                                        select new AdditionalDriverChargeSearchContent
                                        {
                                            AdditionalDriverChargeId = addDriverChrg.AdditionalDriverChargeId,
                                            TariffTypeCode = tariffType.TariffTypeCode,
                                            TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                            AdditionalDriverChargeRate = addDriverChrg.AdditionalDriverChargeRate,
                                            StartDt = addDriverChrg.StartDt,
                                            CompanyCodeName = tariffType.Operation.Department.Company.CompanyCode + " - " + tariffType.Operation.Department.Company.CompanyName,
                                            OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                            RevisionNumber = addDriverChrg.RevisionNumber,
                                            CompanyId = tariffType.Operation.Department.Company.CompanyId,
                                            DepartmentId = tariffType.Operation.Department.DepartmentId,
                                            OperationId = tariffType.Operation.OperationId,
                                            TariffTypeId = tariffType.TariffTypeId,
                                            ChildAdditionalDriverChargeId = addDriverChrg.ChildAdditionalDriverChargeId,
                                        };

            IEnumerable<AdditionalDriverChargeSearchContent> additionalDriverCharges = request.IsAsc
                ? getInsuranceRateQuery.OrderBy(additionalDriverChargeClause[request.AdditionalDriverChargeByOrder])
                    .Skip(fromRow)
                    .Take(toRow).ToList()
                : getInsuranceRateQuery.OrderByDescending(additionalDriverChargeClause[request.AdditionalDriverChargeByOrder])
                    .Skip(fromRow)
                    .Take(toRow).ToList();
            return new AdditionalDriverChargeSearchResponse { AdditionalDriverCharges = additionalDriverCharges, TotalCount = getInsuranceRateQuery.Count() };
        }

        /// <summary>
        /// Get Additional Driver Charge By Tariff Type Code
        /// </summary>
        public IEnumerable<AdditionalDriverCharge> FindByTariffTypeCode(string tariffTypeCode)
        {
            return DbSet.Where(addDriverChrg => addDriverChrg.UserDomainKey == UserDomainKey && addDriverChrg.ChildAdditionalDriverChargeId == null
                && addDriverChrg.TariffTypeCode == tariffTypeCode).ToList();
        }

        /// <summary>
        /// Get Additional Driver Charge Revisions By Id
        /// </summary>
        public AdditionalDriverCharge GetRevision(long additionalDriverChargeId)
        {
            return DbSet.FirstOrDefault(addDriverChrg => addDriverChrg.ChildAdditionalDriverChargeId == additionalDriverChargeId);
        }

        #endregion
    }
}
