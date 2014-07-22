using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.Common;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Standard Rate Main Repository
    /// </summary>
    public sealed class StandardRateMainRepository : BaseRepository<StandardRateMain>, IStandardRateMainRepository
    {
        #region Private
        private readonly Dictionary<TariffRateByColumn, Func<StandardRateMain, object>> tariffRateClause =
             new Dictionary<TariffRateByColumn, Func<StandardRateMain, object>>
                    {
                        { TariffRateByColumn.TariffRateCode, c => c.StandardRtMainCode },
                        
                       
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
        /// <param name="tariffRateRequest"></param>
        /// <returns></returns>
        public TariffRateResponse GetTariffRates(TariffRateRequest tariffRateRequest)
        {
            int fromRow = (tariffRateRequest.PageNo - 1) * tariffRateRequest.PageSize;
            int toRow = tariffRateRequest.PageSize;
            Expression<Func<StandardRateMain, bool>> query =
                            s => ((!(tariffRateRequest.Id > 0) || s.StandardRtMainId == tariffRateRequest.Id));

            IEnumerable<StandardRateMain> tariffRates = tariffRateRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(tariffRateClause[tariffRateRequest.TariffRateByOrder]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(tariffRateClause[tariffRateRequest.TariffRateByOrder]).Skip(fromRow).Take(toRow).ToList();

            return new TariffRateResponse { TariffRates = tariffRates, TotalCount = DbSet.Count(query) };
        }
        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override StandardRateMain Find(long id)
        {
            return DbSet.FirstOrDefault(standardRateMain => standardRateMain.StandardRtMainId == id);
        }
        #endregion
    }
}
