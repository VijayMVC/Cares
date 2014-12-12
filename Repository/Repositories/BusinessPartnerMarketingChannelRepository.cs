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
    /// Business Partner Marketing Channel Repository
    /// </summary>
    public sealed class BusinessPartnerMarketingChannelRepository : BaseRepository<BusinessPartnerMarketingChannel>, IBusinessPartnerMarketingChannelRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerMarketingChannelRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerMarketingChannel> DbSet
        {
            get
            {
                return db.BusinessPartnerMarketingChannels;
            }
        }

        #endregion
        #region Public
        
        /// <summary>
        /// Get All Business Partner Marketing Channels for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerMarketingChannel> GetAll()
        {
            return DbSet.Where(businessPartnerMarketingChannel => businessPartnerMarketingChannel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Business Partner Marketing Channel by Id
        /// </summary>
        public BusinessPartnerMarketingChannel Find(int id)
        {
            return DbSet.FirstOrDefault(bpMarktingChannel => bpMarktingChannel.UserDomainKey==UserDomainKey);
        }

        /// <summary>
        /// Association check bw Marketing Channel and BP MarketingChannel
        /// </summary>
        public bool IsBpMarketingChannelAssociatedWithMarketingChannel(long marketingChannelId)
        {
            return DbSet.Count(bPMarketingChannel =>bPMarketingChannel.UserDomainKey==UserDomainKey &&  bPMarketingChannel.MarketingChannelId == marketingChannelId) > 0;
        }
        #endregion
    }
}
