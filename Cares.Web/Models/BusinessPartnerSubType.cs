
namespace Cares.Web.Models
{
    /// <summary>
    /// Web model
    /// </summary>
    public class BusinessPartnerSubType
    {
        /// <summary>
        /// BusinessPartner SubType ID
        /// </summary>
        public short BusinessPartnerSubTypeId { get; set; }

        /// <summary>
        /// BusinessPartner SubType Code
        /// </summary>
        public string BusinessPartnerSubTypeCode { get; set; }

        /// <summary>
        /// BusinessPartner SubType Key
        /// </summary>
        public short? BusinessPartnerSubTypeKey { get; set; }

        /// <summary>
        /// BusinessPartner SubType Name
        /// </summary>
        public string BusinessPartnerSubTypeName { get; set; }

        /// <summary>
        /// BusinessPartner SubType Description
        /// </summary>
        public string BusinessPartnerSubTypeDescription { get; set; }

        /// <summary>
        /// BusinessPartner MainType ID
        /// </summary>
        public short BusinessPartnerMainTypeId { get; set; }

        /// <summary>
        /// Business Partner Main Type Name
        /// </summary>
        public string BusinessPartnerMainTypeName { get; set; }
    }
}