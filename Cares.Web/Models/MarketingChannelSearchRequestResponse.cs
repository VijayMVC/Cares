using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Marketing Channel Search Request Response web model
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