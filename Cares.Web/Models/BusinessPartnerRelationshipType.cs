
namespace Cares.Web.Models
{
    /// <summary>
    /// Web Model
    /// </summary>
    public class BusinessPartnerRelationshipType
    {
        /// <summary>
        /// BusinessPartner Relationship Type ID
        /// </summary>
        public short BusinessPartnerRelationshipTypeId { get; set; }

        /// <summary>
        /// BusinessPartner Relationship Type Code
        /// </summary>
        public string BusinessPartnerRelationshpTypeCode { get; set; }

        /// <summary>
        /// BusinessPartner Relationship Type Name
        /// </summary>
        public string BusinessPartnerRelationshipTypeName { get; set; }

        /// <summary>
        /// BusinessPartner Relationship Type Description
        /// </summary>
        public string BusinessPartnerRelationshipTypeDescription { get; set; }
    }
}