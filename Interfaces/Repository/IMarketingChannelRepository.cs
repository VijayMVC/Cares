using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Marketing Channel Repository Interface
    /// </summary>
    public interface IMarketingChannelRepository : IBaseRepository<MarketingChannel, short>
    {
        /// <summary>
        /// Search Marketing Channel
        /// </summary>
        IEnumerable<MarketingChannel> SearchMarketingChannel(MarketingChannelSearchRequest request, out int rowCount);

        /// <summary>
        /// MarketingChannel self code duplication check
        /// </summary>
        bool MarketingChannelCodeDuplicationCheck(MarketingChannel marketingChannel);
    }
}
