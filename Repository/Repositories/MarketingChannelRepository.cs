using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
namespace Cares.Repository.Repositories
{
    /// <summary> 
    /// Marketing Channel Repository
    /// </summary>
    public sealed class MarketingChannelRepository : BaseRepository<MarketingChannel>, IMarketingChannelRepository
    {
        #region privte
        /// <summary>
        /// Marketing Channel Orderby clause
        /// </summary>
        private readonly Dictionary<MarketingChannelByColumn, Func<MarketingChannel, object>> marketingChannelOrderByClause = new Dictionary<MarketingChannelByColumn, Func<MarketingChannel, object>>
                    {

                        {MarketingChannelByColumn.Code, c => c.MarketingChannelCode},
                        {MarketingChannelByColumn.Name, n => n.MarketingChannelName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MarketingChannelRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MarketingChannel> DbSet
        {
            get
            {
                return db.MarketingChannels;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Marketing Channels for User Domain Key
        /// </summary>
        public override IEnumerable<MarketingChannel> GetAll()
        {
            return DbSet.Where(marketingChannel => marketingChannel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Marketing Channel By Id
        /// </summary>
        public MarketingChannel Find(short id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Search Marketing Channel
        /// </summary>
        public IEnumerable<MarketingChannel> SearchMarketingChannel(MarketingChannelSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<MarketingChannel, bool>> query =
                marketingChannel =>
                    (string.IsNullOrEmpty(request.MarketingChannelFilterText) ||
                     (marketingChannel.MarketingChannelCode.Contains(request.MarketingChannelFilterText)) ||
                     (marketingChannel.MarketingChannelName.Contains(request.MarketingChannelFilterText)));
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(marketingChannelOrderByClause[request.MarketingChannelOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(marketingChannelOrderByClause[request.MarketingChannelOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList(); 
        }

        /// <summary>
        /// MarketingChannel self code duplication check
        /// </summary>
        public bool MarketingChannelCodeDuplicationCheck(MarketingChannel marketingChannel)
        {
            return
                DbSet.Count(
                    dBmarketingChannel =>
                        dBmarketingChannel.MarketingChannelId != marketingChannel.MarketingChannelId &&
                        dBmarketingChannel.MarketingChannelCode == marketingChannel.MarketingChannelCode) > 0;
        }
        #endregion
    }
}
