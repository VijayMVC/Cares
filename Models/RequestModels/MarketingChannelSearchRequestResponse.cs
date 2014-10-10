using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Marketing Channel Search Request Response Domain mOdel
    /// </summary>
    public class MarketingChannelSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Marketing Channels List
        /// </summary>
        public IEnumerable<MarketingChannel> MarketingChannels { get; set; }

        /// <summary>
        /// Total Count of Marketing Channels
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}
