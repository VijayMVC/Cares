using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Domain Model for Business Partner Marketing Channel
    /// </summary>
    public class BusinessPartnerMarketingChannel
    {
        #region Persisted Properties
        
        /// <summary>
        /// Business Partner Marketing Channel Id
        /// </summary>
        public long BusinessPartnerMarketingChannelId { get; set; }

        /// <summary>
        /// Marketing Channel Id
        /// </summary>
        public short MarketingChannelId { get; set; }

        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
     
        #endregion

        #region Reference Properties

        /// <summary>
        /// Marketing Channel
        /// </summary>
        public virtual MarketingChannel MarketingChannel { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
