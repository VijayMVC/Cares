using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public long BusinessPartnerMarketingChannelId { get; set; }

        /// <summary>
        /// Marketing Channel Id
        /// </summary>
        [ForeignKey("MarketingChannel")]
        public short MarketingChannelId { get; set; }

        /// <summary>
        /// Business Partner Id
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
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
