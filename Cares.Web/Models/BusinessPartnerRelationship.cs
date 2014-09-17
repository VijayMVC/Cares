using System;
namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Relationship Web Api Model
    /// </summary>
    public class BusinessPartnerRelationship
    {
        /// <summary>
        /// Business Partner Relationship Id
        /// </summary>
        public long? BusinessPartnerRelationshipId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Relationship Type Id
        /// </summary>
        public short BusinessPartnerRelationshipTypeId { get; set; }
        /// <summary>
        /// Business Partner Relationship Type Name
        /// </summary>
        public string BusinessPartnerRelationshipTypeName { get; set; }
        /// <summary>
        /// Secondary Business Partner Id
        /// </summary>
        public long SecondaryBusinessPartnerId { get; set; }
        /// <summary>
        /// Secondary Business Partner Code Name
        /// </summary>
        public string SecondaryBusinessPartnerCodeName { get; set; }
    }
}