using System;

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
        public long BusinessPartnerRelationshipId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Business Partner Relationship Type Id
        /// </summary>
        public short BusinessPartnerRelationshipTypeId { get; set; }

        /// <summary>
        /// Secondary Business Partner Id
        /// </summary>
        public long SecondaryBusinessPartnerId { get; set; }

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
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        /// <summary>
        /// Business Partner Relationship Type
        /// </summary>
        public virtual BusinessPartnerRelationshipType BusinessPartnerRelationshipType { get; set; }

        /// <summary>
        /// Secondary Business Partner
        /// </summary>
        public virtual BusinessPartner SecondaryBusinessPartner { get; set; }

        #endregion
    }
}
