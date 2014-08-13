using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Partner Relationship Domain Model
    /// </summary>
    public class BusinessPartnerRelationship
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner Relationship ID
        /// </summary>
        public int BusinessPartnerRelationshipId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Business Partner Relationship Type Id
        /// </summary>
        [ForeignKey("BusinessPartnerRelationshipType")]
        public int BusinessPartnerRelationshipTypeId { get; set; }

        ///// <summary>
        ///// Secondary Business Partner Id
        ///// </summary>
        //[ForeignKey("SecondaryBusinessPartner")]
        //public long SecondaryBusinessPartnerId { get; set; }

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
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        /// <summary>
        /// Business Partner Relationship Type
        /// </summary>
        public virtual BusinessPartnerRelationshipType BusinessPartnerRelationshipType { get; set; }

        ///// <summary>
        ///// Secondary Business Partner
        ///// </summary>
        //public virtual BusinessPartner SecondaryBusinessPartner { get; set; }

        #endregion
    }
}
