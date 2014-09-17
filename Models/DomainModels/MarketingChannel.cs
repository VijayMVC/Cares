using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Marketing Channel Domain Model
    /// </summary>
    public class MarketingChannel
    {
        #region Persisted Properties
        /// <summary>
        /// Marketing Channel Id
        /// </summary>
        public short MarketingChannelId { get; set; }
        /// <summary>
        /// Marketing Channel Code
        /// </summary>
        public string MarketingChannelCode { get; set; }
        /// <summary>
        /// Marketing Channel Name
        /// </summary>
        public string MarketingChannelName { get; set; }
        /// <summary>
        /// Marketing Channel Description
        /// </summary>
        public string MarketingChannelDescription { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
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
        /// Business Partner Marketing Channels
        /// </summary>
        public virtual ICollection<BusinessPartnerMarketingChannel> BusinessPartnerMarketingChannels { get; set; }
        #endregion
    }
}
