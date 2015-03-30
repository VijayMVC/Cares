using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Insurance Rate Main Repository
    /// </summary>
    public sealed class InsuranceRtMainRepository : BaseRepository<InsuranceRtMain>, IInsuranceRtMainRepository
    {
        #region Private
        private readonly Dictionary<InsuranceRateByColumn, Func<InsuranceRtMainContent, object>> insuranceRateClause =
             new Dictionary<InsuranceRateByColumn, Func<InsuranceRtMainContent, object>>
                    {
                        { InsuranceRateByColumn.InsuranceRtCode, c => c.InsuranceRtMainCode },
                        { InsuranceRateByColumn.InsuranceRtName, c => c.InsuranceRtName },
                        { InsuranceRateByColumn.StartDate, c => c.StartDt },
                       
                    };

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRtMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceRtMain> DbSet
        {
            get
            {
                return db.InsuranceRtMains;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Insurance Rate Main for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceRtMain> GetAll()
        {
            return DbSet.Where(insuranceRtMain => insuranceRtMain.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Insurance Rates based on search crateria
        /// </summary>
        public InsuranceRateSearchResponse GetInsuranceRates(InsuranceRateSearchRequest insuranceRateSearchRequest)
        {
            int fromRow = (insuranceRateSearchRequest.PageNo - 1) * insuranceRateSearchRequest.PageSize;
            int toRow = insuranceRateSearchRequest.PageSize;

            var getInsuranceRateQuery = from insuranceRtMain in DbSet
                                        join tariffType in db.TariffTypes.Where(tt => tt.UserDomainKey == UserDomainKey) on insuranceRtMain.TariffTypeCode equals tariffType.TariffTypeCode
                                        where
                                            ((string.IsNullOrEmpty(insuranceRateSearchRequest.SearchString) || insuranceRtMain.InsuranceRtMainCode.Contains(insuranceRateSearchRequest.SearchString) || insuranceRtMain.InsuranceRtMainName.Contains(insuranceRateSearchRequest.SearchString)) &&
                                            (!insuranceRateSearchRequest.OperationId.HasValue ||
                                              tariffType.OperationId == insuranceRateSearchRequest.OperationId.Value) &&
                                             (!insuranceRateSearchRequest.TariffTypeId.HasValue ||
                                              tariffType.TariffTypeId == insuranceRateSearchRequest.TariffTypeId)) && !(tariffType.ChildTariffTypeId.HasValue && insuranceRtMain.UserDomainKey == UserDomainKey && tariffType.UserDomainKey == UserDomainKey)
                                        select new InsuranceRtMainContent
                                        {
                                            InsuranceRtMainId = insuranceRtMain.InsuranceRtMainId,
                                            InsuranceRtMainCode = insuranceRtMain.InsuranceRtMainCode,
                                            InsuranceRtName = insuranceRtMain.InsuranceRtMainName,
                                            InsuranceRtMainDescription = insuranceRtMain.InsuranceRtMainDescription,
                                            StartDt = insuranceRtMain.StartDt,
                                            TariffTypeId = tariffType.TariffTypeId,
                                            TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,
                                            OperationId = tariffType.OperationId,
                                            OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,
                                        };

            IEnumerable<InsuranceRtMainContent> insuranceRtMains = insuranceRateSearchRequest.IsAsc
                ? getInsuranceRateQuery.OrderBy(insuranceRateClause[insuranceRateSearchRequest.InsuranceRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow)
                : getInsuranceRateQuery.OrderByDescending(insuranceRateClause[insuranceRateSearchRequest.InsuranceRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow);

            return new InsuranceRateSearchResponse { InsuranceRtMains = insuranceRtMains, TotalCount = getInsuranceRateQuery.Count() };
        }

        /// <summary>
        /// Get  Insurance Rate Main By Tariff Type Code
        /// </summary>
        public IEnumerable<InsuranceRtMain> FindByTariffTypeCode(string tariffTypeCode)
        {
            return DbSet.Where(insuranceRtMain =>insuranceRtMain.UserDomainKey==UserDomainKey && insuranceRtMain.UserDomainKey == UserDomainKey && insuranceRtMain.TariffTypeCode == tariffTypeCode).ToList();
        }

        /// <summary>
        /// Insurance Rate Main Code validation check
        /// </summary>
        public bool IsInsuranceRtMainCodeExists(string insuranceRtMainCode, long insuranceRtMainId)
        {
            return DbSet.Count(irm =>irm.UserDomainKey==UserDomainKey &&  irm.InsuranceRtMainCode.ToLower().Trim() == insuranceRtMainCode.ToLower().Trim() && irm.UserDomainKey == UserDomainKey && irm.InsuranceRtMainId != insuranceRtMainId) > 0;
        }
        #endregion
    }
}
