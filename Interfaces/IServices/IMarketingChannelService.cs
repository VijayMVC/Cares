
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Marketing Channel Service Interface
    /// </summary>
    public interface IMarketingChannelService
    {

        /// <summary>
        /// Search Marketing Channel
        /// </summary>
        MarketingChannelSearchRequestResponse SearchMarketingChannel(MarketingChannelSearchRequest request);

        /// <summary>
        /// Delete Marketing Channel by id
        /// </summary>
        void DeleteMarketingChannel(long marketingChannelId);

        /// <summary>
        /// Add /Update Marketing Channel
        /// </summary>
        MarketingChannel AddUpdateMarketingChannel(MarketingChannel marketingChannel);

    }
}
