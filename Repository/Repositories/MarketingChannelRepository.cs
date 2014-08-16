using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
namespace Cares.Repository.Repositories
{
    /// <summary> 
    /// Marketing Channel Repository
    /// </summary>
    public sealed class MarketingChannelRepository : BaseRepository<MarketingChannel>, IMarketingChannelRepository
    {
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
        /// <param name="id"></param>
        /// <returns></returns>
        public MarketingChannel Find(short id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
