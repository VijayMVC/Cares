using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Marketing Channel Web Model
    /// </summary>
    public class MarketingChannel
    {
        /// <summary>
        /// Marketing Channel Id
        /// </summary>
        public short MarketingChannelId { get; set; }
        /// <summary>
        /// Marketing Channel Custom Id
        /// </summary>
        public string MarketingChannelCustomId { get; set; }
        /// <summary>
        /// Marketing Channel Code
        /// </summary>
        public string MarketingChannelCode { get; set; }
        /// <summary>
        /// Marketing Channel Name
        /// </summary>
        public string MarketingChannelName { get; set; }
    }
}