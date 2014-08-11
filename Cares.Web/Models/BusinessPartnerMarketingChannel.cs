namespace Cares.Web.Models
{
    /// <summary>
    /// Business Parnter Marketing Channel Web Api Model
    /// </summary>
    public class BusinessPartnerMarketingChannel
    {
        #region Public Properties
        /// <summary>
        /// Business Parnter Marketing Channel Id
        /// </summary>
        public long? BusinessPartnerMarketingChannelId { get; set; }
        /// <summary>
        /// Marketing Channel Id
        /// </summary>
        public short MarketingChannelId { get; set; }
        /// <summary>
        /// Marketing Channel Name
        /// </summary>
        public string MarketingChannelName { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        #endregion

    }
}
