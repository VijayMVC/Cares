using System;
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
    /// Standard Rate Main Repository
    /// </summary>
    public sealed class StandardRateMainRepository : BaseRepository<StandardRateMain>, IStandardRateMainRepository
    {
        #region Private
        private readonly Dictionary<TariffRateByColumn, Func<TariffRateContent, object>> tariffRateClause =
             new Dictionary<TariffRateByColumn, Func<TariffRateContent, object>>
                    {
                        { TariffRateByColumn.TariffRateCode, c => c.StandardRtMainCode },
                        { TariffRateByColumn.Operation, c => c.OperationCodeName }
                    };

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardRateMain> DbSet
        {
            get
            {
                return db.StandardRateMains;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Standard Rates Main for User Domain Key
        /// </summary>
        public override IQueryable<StandardRateMain> GetAll()
        {
            return DbSet.Where(department => department.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Get All Tariff Rates based on search crateria
        /// </summary>
        public TariffRateResponse GetTariffRates(TariffRateRequest tariffRateRequest)
        {
            int fromRow = (tariffRateRequest.PageNo - 1) * tariffRateRequest.PageSize;
            int toRow = tariffRateRequest.PageSize;

            var getTariffRateQuery = from tariffRate in DbSet
                join tariffType in db.TariffTypes on tariffRate.TariffTypeCode equals tariffType.TariffTypeCode
                where
                    ((!tariffRateRequest.OperationId.HasValue ||
                      tariffType.OperationId == tariffRateRequest.OperationId.Value) &&
                     (!tariffRateRequest.TariffTypeId.HasValue ||
                      tariffType.TariffTypeId == tariffRateRequest.TariffTypeId))
                select new TariffRateContent
                {                    
                    StandardRtMainId = tariffRate.StandardRtMainId,
                    StandardRtMainCode = tariffRate.StandardRtMainCode,
                    StandardRtMainName = tariffRate.StandardRtMainName,
                    StandardRtMainDescription = tariffRate.StandardRtMainDescription,
                    StartDt = tariffRate.StartDt,
                    EndDt = tariffRate.EndDt,
                    TariffTypeId = tariffType.TariffTypeId,
                    TariffTypeCodeName = tariffType.TariffTypeCode + " - " + tariffType.TariffTypeName,                    
                    OperationId = tariffType.OperationId,
                    OperationCodeName = tariffType.Operation.OperationCode + " - " + tariffType.Operation.OperationName,                    
                };

            IEnumerable<TariffRateContent> tariffRates = tariffRateRequest.IsAsc
                ? getTariffRateQuery.OrderBy(tariffRateClause[tariffRateRequest.TariffRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow)
                : getTariffRateQuery.OrderByDescending(tariffRateClause[tariffRateRequest.TariffRateByOrder])
                    .Skip(fromRow)
                    .Take(toRow);

            return new TariffRateResponse { TariffRates = tariffRates, TotalCount = getTariffRateQuery.Count() };
        }
        /// <summary>
        /// Find By Id
        /// </summary>
        public override StandardRateMain Find(long id)
        {
            return DbSet.FirstOrDefault(standardRateMain => standardRateMain.StandardRtMainId == id);
        }
        /// <summary>
        /// Find By Tariff Type Code
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        public IEnumerable<StandardRateMain>  FindByTariffTypeCode(string tariffTypeCode)
        {
            return DbSet.Where(standardRateMain => standardRateMain.TariffTypeCode == tariffTypeCode);
        }
        #endregion
    }
}
