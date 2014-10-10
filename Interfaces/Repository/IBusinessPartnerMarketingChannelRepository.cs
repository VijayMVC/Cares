using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Marketing Channel Repository Interface
    /// </summary>
    public interface IBusinessPartnerMarketingChannelRepository : IBaseRepository<BusinessPartnerMarketingChannel, long>
    {
        /// <summary>
        /// Association check bw Marketing Channel and BP MarketingChannel
        /// </summary>
        bool IsBpMarketingChannelAssociatedWithMarketingChannel(long marketingChannelId);
    }
}
